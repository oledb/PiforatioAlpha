using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class ObjectiveCollectionTest
    {
        protected FakeContextFactory factory;
        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
        }

        [Test]
        public void AddNewObjective()
        {
            //Arrange
            var objective = new Objective()
            {
                Name = "Read book MVC for professional",
                Status = ObjectiveStatus.NotStarted,
            };
            var collection = new Objectives(factory);

            //Act
            collection.Create(objective);
            var allObjectives = collection.Read();

            //Assert
            Assert.AreEqual(1, allObjectives.Count);
        }

        [Test]
        public void GetObjectivesByName()
        {
            //Arrange
            var collection = new Objectives(factory);
            collection.Create(new Objective() { Name = "Test Objective" });
            collection.Create(new Objective() { Name = "Read MVC book" });
            collection.Create(new Objective() { Name = "Create web site" });

            //Act
            var mvcObjectives = collection.ReadByNameTemplate("mvc");

            //Assert
            Assert.AreEqual(1, mvcObjectives.Count);
            Assert.AreEqual("Read MVC book", mvcObjectives[0].Name);
        }

        [Test]
        public void GetObjetivesByStatus()
        {
            //Arrange
            var collection = new Objectives(factory);
            collection.Create(new Objective() { Name = "Read mvc-book",
                Status = ObjectiveStatus.Completed });
            collection.Create(new Objective() { Name = "Create Mvc test",
                Status = ObjectiveStatus.InProgress});
            collection.Create(new Objective() { Name = "MVC site",
                Status = ObjectiveStatus.NotStarted});

            //Act
            var inProgressList = collection.ReadByStatus(
                ObjectiveStatus.InProgress);
            var notStartedList = collection.ReadByStatus(
                ObjectiveStatus.NotStarted);

            //Arrnage
            Assert.AreEqual(1, inProgressList.Count);
            Assert.AreEqual("Create Mvc test", inProgressList[0].Name);
            Assert.AreEqual(1, notStartedList.Count);
            Assert.AreEqual("MVC site", notStartedList[0].Name);
        }

        [Test]
        public void UpdateObjective()
        {
            //Arrange
            var oldName = "Crate Mvc stie";
            var newName = "Create Mvc site";
            var collection = new Objectives(factory);
            var objective = new Objective()
            {
                Name = oldName,
                Status = ObjectiveStatus.InProgress
            };
            collection.Create(objective);

            //Act
            objective.Name = newName;
            collection.Update(objective);
            var allObjectives = collection.ReadByNameTemplate(newName);

            //Assert
            Assert.AreEqual(1, allObjectives.Count);
            Assert.AreEqual(newName, allObjectives[0].Name);
            Assert.AreEqual(ObjectiveStatus.InProgress, allObjectives[0].Status);
        }
    }
}
