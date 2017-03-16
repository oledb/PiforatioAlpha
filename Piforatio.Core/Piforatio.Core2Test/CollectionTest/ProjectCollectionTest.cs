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
            var project = new Project()
            {
                Name = "MVC",
                Type = ProjectType.Learn,
                Comment = "Learn MVC and create site"
            };
            var collection = new Projects(factory);

            //Act
            collection.Create(project);
            var allProjects = collection.Read();

            //Assert
            Assert.AreEqual(1, allProjects.Count);
            Assert.AreEqual("MVC", allProjects[0].Name);
            Assert.AreEqual(ProjectType.Learn, allProjects[0].Type);
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
            var allProjects = collection.Read();

            //Assert
            Assert.AreEqual(4, allProjects.Count);
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
            var learnProjects = collection.ReadProjectByType(ProjectType.Learn);

            //Assert
            Assert.AreEqual(1, learnProjects.Count);
            Assert.AreEqual("MVC", learnProjects[0].Name);
        }

        [Test]
        public void UpdateProject()
        {
            //Arrange
            var oldName = "M C V";
            var newName = "MVC";
            var project = new Project()
            {
                Name = oldName,
                Type = ProjectType.Work,
                Comment = "Learn MVC"
            };
            var collection = new Projects(factory);
            collection.Create(project);

            //Act
            project.Name = newName;
            collection.Update(project);
            var result = collection.ReadSingle(p => p.Name == newName);

            //Assert
            Assert.AreEqual(newName, result.Name);
            Assert.AreEqual(ProjectType.Work, result.Type);
            Assert.AreEqual("Learn MVC", result.Comment);
        }

        
    }
}
