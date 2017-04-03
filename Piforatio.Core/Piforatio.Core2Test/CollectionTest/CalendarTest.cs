using System;
using System.Collections.Generic;
using NUnit.Framework;
using Piforatio.Core2;
using Piforatio.Core2Test.Fakes;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class CalendarTest
    {
        private FakeContextFactory _factory;

        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            _factory = new FakeContextFactory();
        }

        [Test]
        public void AddNewWeek()
        {
            //Arrange
            var projects = ProjectsFake.Create(_factory);
            var objectives = ObjectivesFake.Create(_factory, projects);
            var quants = QuantsFake.Create(_factory, objectives);
            var calendar = new Calendar(quants, _factory);

            //Act
            calendar.Create(new Week
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
            var projects = ProjectsFake.Create(_factory);
            var objectives = ObjectivesFake.Create(_factory, projects);
            var quants = QuantsFake.Create(_factory, objectives);
            var calendar = new Calendar(quants, _factory);
            var week9 = Date(2017, 2, 27);
            calendar.Create(new Week {StartDate = week9});

            //Act
            var info = calendar.GetWeekInfo(week9);
            var days = info.Days;
            var total = info.TotalCount;
            var aver = info.AverageCount;

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
