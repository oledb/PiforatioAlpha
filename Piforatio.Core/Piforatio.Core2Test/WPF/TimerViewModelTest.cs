using System;
using Piforatio.WPF;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

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
            Assert.AreEqual("00:00:00", timer.TimeWork);
            Assert.IsNull(timer.TimePause);
            Assert.IsFalse(timer.IsStarted);
            Assert.IsNull(timer.CurrentObjective);
        }

        [Test]
        public void StartTimerViewModel()
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
            Assert.AreEqual("00:00:01", timer.TimeWork);
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
                    timeWorkList.Add(timer.TimeWork);
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
