using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class ProjectCollectionTest
    {
        [Test]
        public void AddNewProjectToCollection()
        {
            //Arrange
            var newProject = new Project()
            {
                ID = 100,
                Name = "MVC",
                Type = ProjectType.Learn,
                Comment = "Learn MVC and create site"
            };
            var collection = new Projects();

            //Act
            collection.Add(newProject);

            //Assert
            Assert.AreEqual(1, collection.Length);
        }

        [Test]
        public void UpdateProject()
        {
            //Arrange
            var oldName = "MCV";
            var newName = "MVC";
            var prj = new Project()
            {
                ID = 10,
                Name = oldName,
                Type = ProjectType.Work,
                Comment = "Learn MVC"
            };
            var collection = new Projects();
            collection.Add(prj);

            //Act
            var changedPrj = new Project()
            {
                Name = newName
            };
            collection.Update(prj.ID, changedPrj);

            //Assert
            Assert.AreEqual(newName, prj.Name);
            Assert.AreEqual(10, prj.ID);
            Assert.AreEqual(ProjectType.Work, prj.Type);
            Assert.AreEqual("Learn MVC", prj.Comment);
        }

        [Test]
        public void GetProjectsByPredicate()
        {
            //Arrange
            var collection = new Projects();
            collection.Add(new Project() { Name = "MVC" });
            collection.Add(new Project() { Name = "JavaScript" });

            //Act
            var list = collection.Get(p => p.Name == "MVC");

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("MVC", list[0].Name);
        }

        
    }
}
