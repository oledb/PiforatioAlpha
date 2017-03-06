using System;
using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class ObjectiveCollectionTest
    {
        [Test]
        public void AddObjectiveToCollection()
        {
            //Arrange
            var obj = new Objective()
            {
                ID = 100,
                Project = "Learn MVC",
                Name = "Read book MVC for professional",
                Status = ObjectiveStatus.NotStarted,
            };
            var collection = new Objectives();

            //Act
            collection.Add(obj);

            //Assert
            Assert.AreEqual(1, collection.Length);
        }

        [Test]
        public void GetObjectivesByName()
        {
            //Arrange
            var collection = new Objectives();
            collection.Add(new Objective() { Name = "Test Objective" });
            collection.Add(new Objective() { Name = "Read MVC book" });
            collection.Add(new Objective() { Name = "Create web site" });

            //Act
            var list = collection.GetObjectives("mvc");

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Read MVC book", list[0].Name);
        }

        [Test]
        public void GetObjetivesByStatus()
        {
            //Arrange
            var collection = new Objectives();
            collection.Add(new Objective() { Name = "Read mvc-book",
                Status = ObjectiveStatus.Completed });
            collection.Add(new Objective() { Name = "Create Mvc test",
                Status = ObjectiveStatus.InProgress});
            collection.Add(new Objective() { Name = "MVC site",
                Status = ObjectiveStatus.NotStarted});

            //Act
            var list1 = collection.GetObjectives(
                ObjectiveStatus.InProgress);
            var list2 = collection.GetObjectives(
                ObjectiveStatus.NotStarted);

            //Arrnage
            Assert.AreEqual(1, list1.Count);
            Assert.AreEqual("Create Mvc test", list1[0].Name);
            Assert.AreEqual(1, list2.Count);
            Assert.AreEqual("MVC site", list2[0].Name);
        }

        [Test]
        public void UpdateObjectives()
        {
            //Arrange
            var oldName = "Crate Mvc stie";
            var newName = "Create Mvc site";
            var collection = new Objectives();
            collection.Add(new Objective()
            {
                ID = 100,
                Name = oldName,
                Project = "Test",
                Status = ObjectiveStatus.InProgress
            });

            //Act
            collection.Update(100, new Objective()
            {
                Name = newName
            });
            var list = collection.GetObjectives(newName);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(newName, list[0].Name);
            Assert.AreEqual("Test", list[0].Project);
            Assert.AreEqual(ObjectiveStatus.InProgress, list[0].Status);
        }
    }
}
