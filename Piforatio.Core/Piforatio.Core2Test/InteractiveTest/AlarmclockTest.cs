using NUnit.Framework;
using Piforatio.Core2;
using System;

namespace Piforatio.Core2Test
{
    [TestFixture]
    class AlarmclockTest
    {
        DateTime today;

        [SetUp]
        public void SetToday()
        {
           today = new DateTime(2017, 3, 3, 13, 20, 00);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void StartAndResetTimer(double wait)
        {
            //Arrange
            Alarmclock clock = new Alarmclock();

            //Act
            clock.Start(today);
            clock.Reset();
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
            Alarmclock clock = new Alarmclock();

            //Act
            clock.Start(today);
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
            Alarmclock clock = new Alarmclock();

            //Act
            clock.Start(today);
            today = Wait(wait);
            clock.Pause(today);
            var a = clock.TotalSeconds;
            today = Wait(wait);
            var b = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(a, b);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void StartAndPauseAndExecuteSomeTimes(double wait)
        {
            //Arrange
            Alarmclock clock = new Alarmclock();
            clock.Start(today);

            //Act
            clock.Execute(Wait(wait));
            clock.Pause(Wait(wait));
            // Wait and press Pause againg.
            clock.Execute(Wait(wait * 2));
            clock.Pause(Wait(wait * 2));
            clock.Execute(Wait(wait * 4));
            var result = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait, result);
        }

        public void StartAndPauseSomeTimes(double wait)
        {
            //Arrange
            Alarmclock clock = new Alarmclock();
            clock.Start(today);

            //Arrange
            clock.Pause(Wait(wait * 1));
            clock.Start(Wait(wait * 2));
            clock.Pause(Wait(wait * 4));
            var result = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait * 3, result);
        }

        [TestCase(3600)]
        public void StartAndWaitingWhenStopped(double wait)
        {
            //Arrange
            Alarmclock clock = new Alarmclock();

            //Act
            clock.Start(today, wait);
            bool run = clock.IsRun;
            today = Wait(wait);
            clock.Execute(today);
            bool stop = clock.IsRun;

            //Assert
            Assert.IsTrue(run);
            Assert.IsFalse(stop);
        }

        [TestCase(3600)]
        public void InvokeEventWhenStop(double wait)
        {
            //Arrange
            bool isStopped = false;
            Alarmclock clock = new Alarmclock();
            clock.OnClockStop += (e, f) => 
            {
                isStopped = true;
            };

            //Act
            clock.Start(today, wait * 2);
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
            int value = 0;
            Alarmclock clock = new Alarmclock();
            clock.OnIntervalReach += (e, f) => 
            {
                value++;
            };
            clock.Start(today, wait, interval);

            //Act
            clock.Execute(Wait(interval));
            clock.Execute(Wait(interval * 2));
            clock.Execute(Wait(interval * 3));
            clock.Execute(Wait(interval * 4));

            //Assert
            Assert.AreEqual(3, value);
        }

        public DateTime Wait(double count)
        {
            return today.AddSeconds(count);
        }
    }
}
