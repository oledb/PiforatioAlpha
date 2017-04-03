using System;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    internal class DateTimeWeekTest
    {
        [Test]
        public void Get9Week2017StartDate()
        {
            //Arrange, Act
            var start = WeekNumber.FirstDateOfWeek(2017, 9);

            //Assert
            Assert.AreEqual(new DateTime(2017, 02, 27).Date, start.Date);
        }

        [Test]
        public void Get9Week2016StartDate()
        {
            //Arrange, Act
            var start = WeekNumber.FirstDateOfWeek(2016, 9);

            //Assert
            Assert.AreEqual(new DateTime(2016, 02, 29).Date, start.Date);
        }
    }
}
