using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class QuantCollectionTest
    {
        [Test]
        public void AddNewQuant()
        {
            //Arrange
            var quantTrue = new Quant()
            {
                QuantID = 1000,
                Time = new DateTime(2017, 3, 25, 10, 30, 00),
                Project = "C# Books",
                Objective = "Piforatio - Logic",
                Comment = "Start new",
                Count = 4
            };
            var quantCollection = new QuantCollection();

            //Act
            quantCollection.Add(quantTrue);

            //Assert
            Assert.AreEqual(1, quantCollection.Length);

        }

        [Test]
        public void GetQuantByDate()
        {
            //Arrange
            var Today = new DateTime(2017, 3, 25);
            var quant1 = new Quant() { Time = new DateTime(2017, 3, 24, 10, 30, 00) };
            var quant2 = new Quant() { Time = new DateTime(2017, 3, 24, 12, 30, 00) };
            var quantIncorrect = new Quant() { Time = Today };

            var quantCollection = new QuantCollection();
            quantCollection.Add(quantIncorrect);
            quantCollection.Add(quant2);
            quantCollection.Add(quant1);

            //Act
            var list = quantCollection.GetQuants(new DateTime(2017, 3, 24));

            //Assert

            Assert.IsTrue(list is ReadOnlyCollection<Quant>);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(quant1, list[0]);
            Assert.AreEqual(quant2, list[1]);
        }

        [Test]
        public void GetQuantByWeek()
        {
            //Arrange
            var quantCollection = new QuantCollection();
            var quant8week = new Quant()
            {
                Time = new DateTime(2017, 02, 26)
            };
            var quant9week = new Quant()
            {
                Time = new DateTime(2017, 02, 27)
            };
            var quant10week = new Quant()
            {
                Time = new DateTime(2017, 03, 06)
            };
            quantCollection.Add(quant8week);
            quantCollection.Add(quant9week);

            //Act
            var list = quantCollection.GetQuants(9, 2017);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(quant9week, list[0]);
        }

        [Test]
        public void UpdateQunat()
        {
            //Arrange
            var oldComment = "Helo wold";
            var newComment = "Hello world";
            var today = new DateTime(2017, 2, 10);
            var quant = new Quant
            {
                QuantID = 100,
                Comment = oldComment,
                Time = today
            };
            var quantCollection = new QuantCollection();
            quantCollection.Add(quant);

            //Act
            var changedId = quantCollection.GetQuants(today)[0].QuantID;
            var changedQuant = new Quant()
            {
                Comment = newComment,
                Time = today
            };
            quantCollection.Update(changedId, changedQuant);
            quant = quantCollection.GetQuants(today)[0];

            //Assert
            Assert.AreEqual(newComment, quant.Comment);
        }
    }
}

