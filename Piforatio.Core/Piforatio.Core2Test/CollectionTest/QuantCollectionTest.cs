using System;
using System.Collections.Generic;
using NUnit.Framework;
using Piforatio.Core2;
using Piforatio.Core2Test.Fakes;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class QuantCollectionTest
    {
        protected FakeContextFactory factory;
        [SetUp]
        public void Recreate()
        {
            FakeContextFactory.CreateDb();
            factory = new FakeContextFactory();
        }
        
        [Test]
        public void AddNewQuant()
        {
            //Arrange
            var quant = new Quant
            {
                Time = new DateTime(2017, 3, 25, 10, 30, 00),
                Comment = "Start new",
                Count = 4
            };
            var collection = new Quants(factory);

            //Act
            collection.Create(quant);
            var allQuants = collection.Read();
            var output = allQuants[0];

            //Assert
            Assert.AreEqual(1, allQuants.Count);
            Assert.AreEqual(new DateTime(2017, 3, 25, 10, 30, 00), output.Time);
            Assert.IsNull(quant.Objective);
        }

        [Test]
        public void GetQuantsByDate()
        {
            //Arrange
            var today = new DateTime(2017, 3, 25);
            var quant2410 = new Quant { Time = new DateTime(2017, 3, 24, 10, 30, 00) };
            var quatn2412 = new Quant { Time = new DateTime(2017, 3, 24, 12, 30, 00) };
            var quant25 = new Quant { Time = today };
            var collection = new Quants(factory);
            collection.Create(quant25);
            collection.Create(quatn2412);
            collection.Create(quant2410);

            //Act
            var day24 = collection.Read(new DateTime(2017, 3, 24));

            //Assert
            Assert.IsTrue(day24 is List<Quant>);
            Assert.AreEqual(2, day24.Count);
            Assert.AreEqual(quant2410.Time, day24[0].Time);
            Assert.AreEqual(quatn2412.Time, day24[1].Time);
        }

        [Test]
        public void GetQuantsByWeek()
        {
            //Arrange
            var collection = new Quants(factory);
            var quant8week = new Quant
            {
                Time = new DateTime(2017, 02, 26)
            };
            var quant9week = new Quant
            {
                Time = new DateTime(2017, 02, 27)
            };
            var quant10week = new Quant
            {
                Time = new DateTime(2017, 03, 06)
            };
            collection.Create(quant8week);
            collection.Create(quant9week);

            //Act
            var week9 = collection.Read(9, 2017);

            //Assert
            Assert.AreEqual(1, week9.Count);
            Assert.AreEqual(quant9week.Time, week9[0].Time);
        }

        [Test]
        public void UpdateQunat()
        {
            //Arrange
            var oldComment = "Helo wold";
            var newComment = "Hello world";
            var today = new DateTime(2017, 2, 10);
            var collection = new Quants(factory);
            collection.Create(new Quant
            {
                Comment = oldComment,
                Time = today
            });

            //Act
            var quant = collection.ReadSingle(d => d.Time == today);
            quant.Comment = newComment;
            collection.Update(quant);
            var result = collection.ReadSingle(d => d.Time == today);

            //Assert
            Assert.AreEqual(newComment, result.Comment);
        }

        [Test]
        public void DeleteQuant()
        {
            //Arrange
            var collection = new Quants(factory);
            collection.Create(new Quant
            {
                Time = new DateTime(2017, 3, 25, 10, 30, 00),
                Comment = "Start new",
                Count = 4
            });

            //Act
            var quant = collection.ReadSingle(d => d.Comment == "Start new");
            collection.Delete(quant);
            quant = collection.ReadSingle(d => d.Comment == "Start new");

            //Assert
            Assert.IsNull(quant);
        }

        // Tests with Objectives.

        [Test]
        public void AddNewQuantWithObjective()
        {
            //Arrange
            var objectives = ObjectivesFake.Create(factory);
            var objective = objectives.ReadSingle(o => o.Name == "Read book about Mvc");
            var collection = new Quants(factory);
            collection.Create(new Quant
            {
                Comment = "Create new 1",
                Objective = objective
            });
            collection.Create(new Quant
            {
                Comment = "Create new 2",
                Objective = objective
            });

            //Act
            var allQuants = collection.Read();
            var quant = collection.ReadSingle(q => q.Comment == "Create new 1");

            //Assert
            Assert.IsNotNull(quant);
            Assert.IsNotNull(quant.Objective);
            Assert.AreEqual(2, allQuants.Count);
            Assert.AreEqual("Read book about Mvc", quant.Objective.Name);
        }

        
        [Test]
        public void AddObjectiveToQuant()
        {
            //Arrange
            var objectives = ObjectivesFake.Create(factory);
            var objective = objectives.ReadSingle(o => o.Name == "Read book about Mvc");
            var collection = new Quants(factory);
            collection.Create(new Quant
            {
                Comment = "Create new",
                Time = DateTime.Now
            });
            var quant = collection.ReadSingle(q => q.Comment == "Create new");

            //Act
            quant.Objective = objective;
            collection.Update(quant);
            var result = collection.ReadSingle(q => q.Comment == "Create new");

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Objective, "Objective is null");
        }

        [Test]
        public void ChangeObjectiveInQuant()
        {
            //Arrange
            var objectives = ObjectivesFake.Create(factory);
            var objectiveOld = objectives.ReadSingle(o => o.Name == "Read book about Mvc");
            var objectiveNew = objectives.ReadSingle(o => o.Name == "Find work");
            var collection = new Quants(factory);
            collection.Create(new Quant
            {
                Comment = "Create new 1",
                Objective = objectiveOld,
                Time = DateTime.Now
            });

            //Act
            var quant = collection.ReadSingle(q => q.Comment == "Create new 1");
            quant.Objective = objectiveNew;
            collection.Update(quant);
            var output = collection.ReadSingle(q => q.Comment == "Create new 1");

            //Assert
            Assert.IsNotNull(output.Objective);
            Assert.AreEqual("Find work", output.Objective.Name);
        }
    }
}

