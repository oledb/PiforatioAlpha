﻿using System;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    internal class AlarmclockTest
    {
        [SetUp]
        public void SetToday()
        {
            _today = new DateTime(2017, 3, 3, 13, 20, 00);
        }

        private DateTime _today;

        [TestCase(1)]
        [TestCase(5)]
        public void StartAndResetTimer(double wait)
        {
            //Arrange
            var clock = new Alarmclock();

            //Act
            clock.Start(_today);
            clock.Stop();
            clock.Execute(Wait(wait));
            var totalSeconds = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(0, totalSeconds);
        }

        [TestCase(1)]
        [TestCase(100000)]
        public void StartAndGetTotalSeconds(double wait)
        {
            //Arrange
            var clock = new Alarmclock();

            //Act
            clock.Start(_today);
            clock.Execute(Wait(wait));
            var totalSeconds = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait, totalSeconds);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void StartAndPause(double wait)
        {
            //Arrange
            var clock = new Alarmclock();

            //Act
            clock.Start(_today);
            _today = Wait(wait);
            clock.Pause(_today);
            var a = clock.TotalSeconds;
            _today = Wait(wait);
            var b = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(a, b);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void StartAndPauseAndExecuteSomeTimes(double wait)
        {
            //Arrange
            var clock = new Alarmclock();
            clock.Start(_today);

            //Act
            clock.Execute(Wait(wait));
            clock.Pause(Wait(wait));
            // Wait and press Pause againg.
            clock.Execute(Wait(wait * 12));
            clock.Pause(Wait(wait * 14));
            clock.Execute(Wait(wait * 16));
            var result = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait, result);
        }

        [TestCase(100)]
        public void StartAndPauseSomeTimes(double wait)
        {
            //Arrange
            var clock = new Alarmclock();
            clock.Start(_today);

            //Arrange
            clock.Pause(Wait(wait * 1));
            clock.Start(Wait(wait * 14));
            clock.Pause(Wait(wait * 16));
            var result = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait * 3, result);
        }

        [TestCase(3600)]
        public void StartAndWaitingWhenStopped(double wait)
        {
            //Arrange
            var clock = new Alarmclock();

            //Act
            clock.Start(_today, wait);
            var run = clock.IsStarted;
            _today = Wait(wait);
            clock.Execute(_today);
            var stop = clock.IsStarted;

            //Assert
            Assert.IsTrue(run);
            Assert.IsFalse(stop);
        }

        [TestCase(3600)]
        public void InvokeEventWhenStop(double wait)
        {
            //Arrange
            var isStopped = false;
            var clock = new Alarmclock();
            clock.OnClockStop += (e, f) => { isStopped = true; };

            //Act
            clock.Start(_today, wait * 2);
            clock.Execute(Wait(wait));
            Assert.IsFalse(isStopped);
            clock.Execute(Wait(wait * 2));

            //Assert
            Assert.IsTrue(isStopped);
        }

        [TestCase(3600, 900)]
        [TestCase(400, 100)]
        public void InvokeEventWhenIntervalIsReached(double wait, double interval)
        {
            //Arrange
            var value = 0;
            var clock = new Alarmclock();
            clock.OnIntervalReach += (e, f) => { value++; };
            clock.Start(_today, wait, interval);

            //Act
            clock.Execute(Wait(interval));
            clock.Execute(Wait(interval * 2));
            clock.Execute(Wait(interval * 3));
            clock.Execute(Wait(interval * 4));

            //Assert
            Assert.AreEqual(3, value);
        }

        [TestCase(400, 100, 50)]
        public void TwoTimeExecuteInOrderToReachInterval(double wait, double interval,
            double executeInterval)
        {
            //Arrange
            var value = 0;
            var clock = new Alarmclock();
            clock.OnIntervalReach += (e, f) => { value++; };
            clock.Start(_today, wait, interval);

            //Act
            clock.Execute(Wait(executeInterval));
            clock.Execute(Wait(executeInterval * 2));
            clock.Execute(Wait(executeInterval * 3));
            clock.Execute(Wait(executeInterval * 4));

            //Assert
            Assert.AreEqual(2, value);
        }

        public DateTime Wait(double count)
        {
            return _today.AddSeconds(count);
        }
    }
}