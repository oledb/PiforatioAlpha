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
        public void AddObjectiveToCollection()
        {
            //Arrange
            var obj = new Objective()
            {
                ID = 100,
                Project = new Project() { Name = "Learn MVC" },
                Name = "Read book MVC for professional",
                Status = ObjectiveStatus.NotStarted,
            };
            var collection = new Objectives(factory);

            //Act
            collection.Create(obj);
            var list = collection.Read();

            //Assert
            Assert.AreEqual(1, list.Count);
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
            var list = collection.ReadByNameTemplate("mvc");

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Read MVC book", list[0].Name);
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
            var list1 = collection.ReadObjectives(
                ObjectiveStatus.InProgress);
            var list2 = collection.ReadObjectives(
                ObjectiveStatus.NotStarted);

            //Arrnage
            Assert.AreEqual(1, list1.Count);
            Assert.AreEqual("Create Mvc test", list1[0].Name);
            Assert.AreEqual(1, list2.Count);
            Assert.AreEqual("MVC site", list2[0].Name);
        }

        [Ignore("This test does not work because Project is not released yet for PiforatioContext")]
        [Test]
        public void UpdateObjectives()
        {
            //Arrange
            var oldName = "Crate Mvc stie";
            var newName = "Create Mvc site";
            var collection = new Objectives(factory);
            var objective = new Objective()
            {
                Name = oldName,
                Project = new Project() { Name = "Test" },
                Status = ObjectiveStatus.InProgress
            };
            collection.Create(objective);

            //Act
            objective.Name = newName;
            collection.Update(objective);
            var list = collection.ReadByNameTemplate(newName);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(newName, list[0].Name);
            Assert.AreEqual("Test", list[0].Project.Name);
            Assert.AreEqual(ObjectiveStatus.InProgress, list[0].Status);
        }
    }
}
