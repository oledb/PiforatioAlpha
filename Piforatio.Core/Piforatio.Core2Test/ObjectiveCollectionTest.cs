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
                ObjectiveID = 100,
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
    }
}
