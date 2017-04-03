using System;
using System.Linq;
using NUnit.Framework;
using Piforatio.Core2;
using Piforatio.Core2Test.Fakes;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class PlanCollectionTest
    {
        protected FakeContextFactory factory;
        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
        }

        [Test]
        public void AddNewPlan()
        {
            //Arrange
            var projects = ProjectsFake.Create(factory);
            var objectives = ObjectivesFake.Create(factory, projects);
            var plan = new Plan
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadByNameTemplate("Read book").FirstOrDefault()
            };
            var collection = new Plans(factory);

            //Act
            collection.Create(plan);
            var allPlans = collection.Read();

            //Assert
            Assert.AreEqual(1, allPlans.Count);
            Assert.AreEqual(new DateTime(2017, 3, 3), allPlans[0].Date);
            Assert.IsNotNull(allPlans[0].Objective);
            Assert.IsNotNull(allPlans[0].Objective.Project);
        }

        [Test]
        public void GetPlansByDate()
        {
            //Arrange
            var projects = ProjectsFake.Create(factory);
            var objectives = ObjectivesFake.Create(factory, projects);
            var collection = new Plans(factory);
            collection.Create( new Plan
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadByNameTemplate("Read book")[0]
            });
            collection.Create( new Plan
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadByNameTemplate("Create test site")[0]
            });
            collection.Create(new Plan
            {
                Date = new DateTime(2017, 3, 4),
                Objective = objectives.ReadByNameTemplate("Create test site")[0]
            });

            //Act
            var list = collection.ReadByDate(new DateTime(2017, 3, 3));

            //Assert
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void UpdatePlan()
        {
            //Arrange
            var projects = ProjectsFake.Create(factory);
            var objectives = ObjectivesFake.Create(factory, projects);
            var collection = new Plans(factory);
            collection.Create(new Plan
            {
                Date = new DateTime(2017, 3, 3),
                Objective = objectives.ReadByNameTemplate("Read book").FirstOrDefault()
            });

            //Act
            var plan = collection.ReadByDate(new DateTime(2017, 3, 3)).FirstOrDefault();
            plan.Date = new DateTime(2017, 3, 5);
            collection.Update(plan);
            var list = collection.ReadByDate(new DateTime(2017, 3, 5));

            //Assert
            Assert.AreEqual(1, list.Count);
        }
    }
}
