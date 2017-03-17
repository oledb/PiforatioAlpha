using NUnit.Framework;
using Piforatio.Core2;
using System;
using Moq;

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
        [TestCase(100000)]
        public void StartAndStopTimerForXSeconds(int wait)
        {
            //Arrange
            Alarmclock clock = new Alarmclock();

            //Act
            clock.Start(today);
            clock.Stop(today.AddSeconds(wait));
            var totalSeconds = clock.TotalSeconds;

            //Assert
            Assert.AreEqual(wait, totalSeconds);
        }

        public void StartGetTotalSeconds()
        {

        }
    }
}
