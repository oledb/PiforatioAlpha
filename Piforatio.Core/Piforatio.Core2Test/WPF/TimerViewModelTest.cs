using System;
using System.Collections.Generic;
using NUnit.Framework;
using Piforatio.WPF;

namespace Piforatio.Core2Test.WPF
{
    [TestFixture]
    internal class TimerViewModelTest
    {
        //3.22.2017 6.16pm
        [TestCase(636258034072347780)]
        //3.23.2017 4.34pm
        [TestCase(636258836307637505)]
        public void CreateTimerViewModel(long today)
        {
            //Arrange, Act
            var time = new DateTime(today, DateTimeKind.Local);
            IDateTime dateTime = new TodayStub(time);
            var timer = new TimerViewModel(dateTime);

            //Assert
            Assert.AreEqual("00:00:00", timer.ClockFace);
            Assert.IsFalse(timer.IsStarted);
            Assert.IsFalse(timer.IsPaused);
            Assert.IsNull(timer.CurrentObjective);
        }

        [Test]
        public void StartAndExecute()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 1);
            var timer = new TimerViewModel(dateTime);
            var isStarted = false;
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "IsStarted")
                    isStarted = true;
            };

            //Act
            timer.Start();
            timer.Execute();

            //Assert
            Assert.AreEqual("00:00:01", timer.ClockFace);
            Assert.IsTrue(timer.IsStarted);
            Assert.IsTrue(isStarted);
        }

        [Test]
        public void StartTimerAndEndWhenMaxTimeReached()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 3600);
            var timer = new TimerViewModel(dateTime, 7200);
            var timeWorkList = new List<string>();
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "ClockFace")
                    timeWorkList.Add(timer.ClockFace);
            };
            var isStarted = true;
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "IsStarted")
                    isStarted = false;
            };

            //Act
            timer.Start();
            timer.Execute();
            timer.Execute();

            //Assert
            Assert.AreEqual(2, timeWorkList.Count);
            Assert.AreEqual("01:00:00", timeWorkList[0]);
            Assert.AreEqual("00:00:00", timeWorkList[1]);
            Assert.IsFalse(isStarted);
        }

        [Test]
        public void StartAndStop()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 10);
            var timer = new TimerViewModel(dateTime, 7200);
            var timeWorkList = new List<string>();
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "ClockFace")
                    timeWorkList.Add(timer.ClockFace);
            };

            //Act
            timer.Start();
            timer.Execute();
            timer.Execute();
            timer.Stop();

            //Assert
            Assert.AreEqual(3, timeWorkList.Count);
            Assert.AreEqual("00:00:10", timeWorkList[0]);
            Assert.AreEqual("00:00:20", timeWorkList[1]);
            Assert.AreEqual("00:00:00", timeWorkList[2]);
        }

        [Test]
        public void StartAndPause()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 100);
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);

            //Action
            timer.Start();
            timer.Execute();
            timer.Pause();
            timer.Execute();

            //Assert
            Assert.AreEqual("00:13:19", timer.ClockFace);
            Assert.IsTrue(timer.IsPaused);

        }

        [Test]
        public void StartPauseTimer()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 1);
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);

            //Action
            timer.Start();
            timer.Pause();
            timer.Execute();
            timer.Execute();

            //Assert
            Assert.AreEqual("00:14:57", timer.ClockFace);
        }

        [Test]
        public void StopWhenPauseEnded()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 10);
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);
            timer.MaxPauseTime = 20;
            var pauseTimeList = new List<string>();
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "ClockFace")
                    pauseTimeList.Add(timer.ClockFace);
            };

            //Action
            timer.Start();
            timer.Pause();
            for (int i = 0; i < 10; i++)
                timer.Execute();

            //Assert
            Assert.IsFalse(timer.IsStarted);
            Assert.IsFalse(timer.IsPaused);
            Assert.AreEqual(4, pauseTimeList.Count);
            Assert.AreEqual("00:00:20", pauseTimeList[0]);
            Assert.AreEqual("00:00:10", pauseTimeList[1]);
        }

        [Test]
        public void PauseAndResume()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 10);
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);

            //Act
            timer.Start();
            timer.Pause();
            timer.Execute();
            timer.Execute();
            timer.Execute();
            timer.Execute();
            timer.Start();
            timer.Execute();

            //Assert
            Assert.AreEqual("00:00:20", timer.ClockFace);
        }

        /// 
        /// Events test
        /// 
        [Test]
        public void EventOfPauseTimeEnded()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 450);
            var timer = new TimerViewModel(dateTime, 900);
            var value = 0;
            timer.OnTimerStop += (obj, args) => { value++; };

            //Act
            timer.Start();

            //value++
            timer.Stop();
            timer.Start();
            timer.Execute();
            //value++ 
            timer.Execute();

            //Assert
            Assert.AreEqual(2, value);
        }

        [Test]
        public void IntervalIsReached()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 450);
            var timer = new TimerViewModel(dateTime, 7200);
            int index = 0;
            timer.OnIntervalReached += (obj, args) => index++;

            //Act
            timer.Start();
            for (int i = 0; i < 8; i++)
                timer.Execute();

            //Assert
            Assert.AreEqual(4, index);
        }
    }

    /// Subsidiary classes
    public class TodayStub : IDateTime
    {
        protected DateTime TodayTime;
        public TodayStub(DateTime now)
        {
            TodayTime = now;
        }

        public virtual DateTime Now => TodayTime;
    }

    public class TodayFakeIncrement : TodayStub
    {
        private int _index;
        private readonly int _interval;

        public TodayFakeIncrement(DateTime now, int interval) : base(now)
        {
            _interval = interval;
        }

        public override DateTime Now
        {
            get
            {
                _index += _interval;
                return TodayTime.AddSeconds(_index);
            }
        }
    }
}
