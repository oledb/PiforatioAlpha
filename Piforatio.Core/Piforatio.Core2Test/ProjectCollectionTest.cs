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
        protected FakeContextFactory factory;
        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
        }

        [Test]
        public void AddNewProjectToCollection()
        {
            //Arrange
            var newProject = new Project()
            {
                Name = "MVC",
                Type = ProjectType.Learn,
                Comment = "Learn MVC and create site"
            };
            var collection = new Projects(factory);

            //Act
            collection.Create(newProject);
            var list = collection.Read();

            //Assert
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void UpdateProject()
        {
            //Arrange
            var oldName = "MCV";
            var newName = "MVC";
            var prj = new Project()
            {
                Name = oldName,
                Type = ProjectType.Work,
                Comment = "Learn MVC"
            };
            var collection = new Projects(factory);
            collection.Create(prj);

            //Act
            var changedPrj = new Project()
            {
                Name = newName
            };
            collection.Update(changedPrj);

            //Assert
            Assert.AreEqual(newName, prj.Name);
            Assert.AreEqual(ProjectType.Work, prj.Type);
            Assert.AreEqual("Learn MVC", prj.Comment);
        }

        [Test]
        public void GetProjectByPredicate()
        {
            //Arrange
            var collection = new Projects(factory);
            collection.Create(new Project() { Name = "MVC" });
            collection.Create(new Project() { Name = "JavaScript" });

            //Act
            var project = collection.ReadSingle(p => p.Name == "MVC");

            //Assert
            Assert.IsNotNull(project);
            Assert.AreEqual("MVC", project.Name);
        }

        [Test]
        public void GetProjectsByType()
        {
            //Arrange
            var collection = new Projects(factory);
            collection.Create(new Project()
            {
                Name = "MVC",
                Type = ProjectType.Learn
            });
            collection.Create(new Project()
            {
                Name = "Java",
                Type = ProjectType.Work
            });

            //Act
            var list = collection.ReadProjectByType(ProjectType.Learn);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("MVC", list[0].Name);
        }
        
        [Test]
        public void GetAllProjects()
        {
            //Arrange
            var collection = new Projects(factory);
            collection.Create(new Project());
            collection.Create(new Project());
            collection.Create(new Project());
            collection.Create(new Project());

            //Act
            var list = collection.Read();

            //Assert
            Assert.AreEqual(4, list.Count);
        }
    }
}
