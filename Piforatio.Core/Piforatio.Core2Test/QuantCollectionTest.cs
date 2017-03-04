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

        [Ignore("Fake")]
        [Test]
        public void GetQuantByWeek()
        {
            //Arrange
            var quantCollection = new QuantCollection();
            var quant5week = new Quant()
            {
                Time = new DateTime(2017, 02, 27)
            };
            var quant4week = new Quant()
            {
                Time = new DateTime(2017, 02, 26)
            };
            quantCollection.Add(quant4week);
            quantCollection.Add(quant5week);

            //Act
            var list = quantCollection.GetQuants(5);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(quant5week, list[0]);
        }

    }
}

