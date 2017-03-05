using System;
using System.Collections.Generic;
using System.Linq;
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
            var objs = new ObjectiveCollection();

            //Act
            objs.Add(obj);

            //Assert
            Assert.AreEqual(1, objs.Length);
        }
    }
}
