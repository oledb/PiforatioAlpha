using System;
using Piforatio.WPF;
using NUnit.Framework;
using System.Collections.Generic;

namespace Piforatio.Core2Test.WPF
{
    [TestFixture]
    class TimerViewModelTest
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
            TimerViewModel timer = new TimerViewModel(dateTime);

            //Assert
            Assert.AreEqual("00:00:00", timer.WorkTime);
            Assert.IsNull(timer.PauseTime);
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
            TimerViewModel timer = new TimerViewModel(dateTime);
            bool isStarted = false;
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "IsStarted")
                    isStarted = true;
            };

            //Act
            timer.Start();
            timer.Execute();

            //Assert
            Assert.AreEqual("00:00:01", timer.WorkTime);
            Assert.IsTrue(timer.IsStarted);
            Assert.IsTrue(isStarted);
        }

        [Test]
        public void StartTimerAndEndWhenMaxTimeReached()
        {
            //Arrange
            var time = new DateTime(636258836307637505, DateTimeKind.Local);
            IDateTime dateTime = new TodayFakeIncrement(time, 3600);
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);
            var timeWorkList = new List<string>();
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "TimeWork")
                    timeWorkList.Add(timer.WorkTime);
            };
            bool isStarted = true;
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
            TimerViewModel timer = new TimerViewModel(dateTime, 7200);
            var timeWorkList = new List<string>();
            timer.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "TimeWork")
                    timeWorkList.Add(timer.WorkTime);
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
            Assert.AreEqual("00:03:20", timer.WorkTime);
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
            Assert.AreEqual("00:14:58", timer.PauseTime);
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
                if (args.PropertyName == "PauseTime")
                    pauseTimeList.Add(timer.PauseTime);
            };

            //Action
            timer.Start();
            timer.Pause();
            timer.Execute();
            timer.Execute();

            //Assert
            Assert.IsFalse(timer.IsStarted);
            Assert.AreEqual(2, pauseTimeList.Count);
            Assert.AreEqual("00:00:10", pauseTimeList[0]);
            Assert.AreEqual("00:00:00", pauseTimeList[1]);
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
            Assert.AreEqual("00:00:20",timer.WorkTime);
        }
    }

    public class TodayStub : IDateTime
    {
        protected DateTime _now;
        public TodayStub(DateTime now)
        {
            _now = now;
        }

        public virtual DateTime Now
        {
            get { return _now; }
        }
    }

    public class TodayFakeIncrement : TodayStub
    {
        private int _index = 0;
        private int _interval = 0;

        public TodayFakeIncrement(DateTime now, int interval) : base(now)
        {
            _interval = interval;
        }

        public override DateTime Now
        {
            get
            {
                _index += _interval;
                return _now.AddSeconds(_index);
            }
        }
    }
}
