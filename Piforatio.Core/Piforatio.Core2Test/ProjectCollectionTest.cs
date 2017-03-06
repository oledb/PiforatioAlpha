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
        public void GetProjectByPredicate()
        {
            //Arrange
            var collection = new Projects();
            collection.Add(new Project() { Name = "MVC" });
            collection.Add(new Project() { Name = "JavaScript" });

            //Act
            var project = collection.GetSingle(p => p.Name == "MVC");

            //Assert
            Assert.AreEqual(typeof(Project), project.GetType());
            Assert.AreEqual("MVC", project.Name);
        }

        [Test]
        public void GetProjectsByType()
        {
            //Arrange
            var collection = new Projects();
            collection.Add(new Project()
            {
                Name = "MVC",
                Type = ProjectType.Learn
            });
            collection.Add(new Project()
            {
                Name = "Java",
                Type = ProjectType.Work
            });

            //Act
            var list = collection.GetProjects(ProjectType.Learn);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("MVC", list[0].Name);
        }
        
        [Test]
        public void GetAllProjects()
        {
            //Arrange
            var collection = new Projects();
            collection.Add(new Project());
            collection.Add(new Project());
            collection.Add(new Project());
            collection.Add(new Project());

            //Act
            var list = collection.GetProjects();

            //Assert
            Assert.AreEqual(4, list.Count);
        }
    }
}
