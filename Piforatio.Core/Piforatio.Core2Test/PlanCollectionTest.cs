using System;
using System.Collections.Generic;
using System.Linq;
using Piforatio.Core2Test.Fakes;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class PlanCollectionTest
    {
        [Test]
        public void CreateCalendar()
        {
            //Arrange
            var projects = ProjectsFake.Create();
            var objectives = ObjectivesFake.Create(projects);
            var plan = new Plan()
            {
                ID = 10,
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.GetObjectives("Read book")[0]
            };
            var plans = new Plans();

            //Act
            plans.Add(plan);

            //Assert
            Assert.AreEqual(1, plans.Length);
        }

        [Test]
        public void GetPlansByDate()
        {
            //Arrange
            var projects = ProjectsFake.Create();
            var objectives = ObjectivesFake.Create(projects);
            var plans = new Plans();
            plans.Add( new Plan()
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.GetObjectives("Read book")[0]
            });
            plans.Add( new Plan()
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.GetObjectives("Read book")[0]
            });
            

            //Act
            //Assert
        }
    }
}
