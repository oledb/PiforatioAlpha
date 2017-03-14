using System;
using NUnit.Framework;
using System.Collections.Generic;
using Piforatio.Core2;
using Piforatio.Core2Test.Fakes;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class CalendarTest
    {
        [Test]
        public void CreateCalendar()
        {
            //Arrange
            var projects = ProjectsFake.Create();
            var objectives = ObjectivesFake.Create(projects);
            var quants = QuantsFake.Create(objectives);
            var calendar = new Calendar(quants);

            //Act
            calendar.Add(new Week()
            {
                ID = 19,
                StartDate = Date(2017, 2, 27)
            });

            //Assert
            Assert.AreEqual(1, calendar.Length);
        }

        [Test]
        public void GetCountsWeekInfo()
        {
            //Arrange
            FakeContextFactory.CreateDb();
            var projects = ProjectsFake.Create();
            var objectives = ObjectivesFake.Create(projects);
            var quants = QuantsFake.Create(objectives);
            var calendar = new Calendar(quants);
            var week9 = Date(2017, 2, 27);
            calendar.Add( new Week() { StartDate = week9 });

            //Act
            WeekInfo info = calendar.GetWeekInfo(week9);
            Dictionary<DateTime, int> days = info.Days;
            int total = info.TotalCount;
            double aver = info.AverageCount;

            //Assert
            Assert.AreEqual(7, days.Count);
            Assert.AreEqual(days[Date(2017, 2, 28)], 8);
            Assert.AreEqual(days[Date(2017, 3, 1)], 9);
            Assert.AreEqual(days[Date(2017, 3, 2)], 6);
            Assert.AreEqual(8 + 9 + 6, total);
            Assert.AreEqual(3.25, aver);
        }

        public DateTime Date(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }
    }
}
