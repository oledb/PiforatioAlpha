using System;
using Piforatio.WPF;
using NUnit.Framework;

namespace Piforatio.Core2Test.WPF
{
    [TestFixture]
    class TimerViewModelTest
    {
                  //3.22.2017 6.16pm
        [TestCase(636258034072347780, "6822")]
                  //3.23.2017 4.34pm
        [TestCase(636258836307637505, "6799")]
        public void CreateTimerViewModel(long today, string endYearResult)
        {
            //Arrange, Act
            var time = new DateTime(today, DateTimeKind.Local);
            IDateTime dateTime = new TodayStub(time);
            TimerViewModel timer = new TimerViewModel(dateTime);

            //Assert
            Assert.AreEqual(endYearResult, timer.EndYear);
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
            IDateTime dateTime = new TodayStub(time);
            TimerViewModel timer = new TimerViewModel(dateTime);

            //Act
            //timer.Start();
            //timer.Execute();

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

    public class Today1SecFake : TodayStub
    {
        private int _index;

        public Today1SecFake(DateTime now) : base(now) { }

        public override DateTime Now
        {
            get
            {
                _index++;
                return _now.AddSeconds(_index);
            }
        }
    }
}
