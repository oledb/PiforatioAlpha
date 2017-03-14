using System;
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
                Objective = objectives.ReadObjectives("Read book")[0]
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
                Objective = objectives.ReadObjectives("Read book")[0]
            });
            plans.Add( new Plan()
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadObjectives("Create test site")[0]
            });
            plans.Add(new Plan()
            {
                Date = new DateTime(2017, 3, 4),
                Objective = objectives.ReadObjectives("Create test site")[0]
            });

            //Act
            var list = plans.GetPlans(new DateTime(2017, 3, 3));

            //Assert
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void UpdatePlan()
        {
            //Arrange
            var projects = ProjectsFake.Create();
            var objectives = ObjectivesFake.Create(projects);
            var plans = new Plans();
            plans.Add(new Plan()
            {
                ID = 12,
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadObjectives("Read book")[0]
            });

            //Act
            plans.Update(12, new Plan() { Date = new DateTime(2017, 3, 5) });
            var list = plans.GetPlans(new DateTime(2017, 3, 5));

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(12, list[0].ID);
            Assert.AreEqual(1, plans.Length);
        }
    }
}
