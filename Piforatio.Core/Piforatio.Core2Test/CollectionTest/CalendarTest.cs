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
        protected FakeContextFactory factory;
        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
            var quants = new Quants(factory);
            var list = quants.Read();
        }

        [Test]
        public void CreateCalendar()
        {
            //Arrange
            var projects = ProjectsFake.Create(factory);
            var objectives = ObjectivesFake.Create(factory, projects);
            var quants = QuantsFake.Create(factory, objectives);
            var calendar = new Calendar(quants, factory);

            //Act
            calendar.Create(new Week()
            {
                StartDate = Date(2017, 2, 27)
            });
            var allWeeks = calendar.Read();

            //Assert
            Assert.AreEqual(1, allWeeks.Count);
        }

        [Test]
        public void GetCountsWeekInfo()
        {
            //Arrange
            var projects = ProjectsFake.Create(factory);
            var objectives = ObjectivesFake.Create(factory, projects);
            var quants = QuantsFake.Create(factory, objectives);
            var list = quants.Read();
            var calendar = new Calendar(quants, factory);
            var week9 = Date(2017, 2, 27);
            calendar.Create( new Week() { StartDate = week9 });

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
