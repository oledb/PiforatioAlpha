using System;
using System.Collections.Generic;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    class DateTimeWeekTest
    {
        [Test]
        public void Get9WeekStartDates()
        {
            //Arrange
            DateTime start;

            //Act
            start = WeekNumber.FirstDateOfWeek(2017, 9);

            //Assert
            Assert.AreEqual(new DateTime(2017, 02, 27).Date, start.Date);
        }
    }
}
