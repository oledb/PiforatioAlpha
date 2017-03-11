﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using Piforatio.Core2;

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
            var quantTrue = new Quant()
            {
                Time = new DateTime(2017, 3, 25, 10, 30, 00),
                Objective = new Objective()
                {
                    Name = "Learn MVC"
                },
                Comment = "Start new",
                Count = 4
            };
            var quantCollection = new Quants(factory);

            //Act
            quantCollection.Create(quantTrue);
            var list = quantCollection.Read();
            var quant = list[0];

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(new DateTime(2017, 3, 25, 10, 30, 00), quant.Time);
            Assert.IsNull(quant.Objective);

        }

        [Test]
        public void DeleteNewQuant()
        {
            //Arrange
            var quantTrue = new Quant()
            {
                Time = new DateTime(2017, 3, 25, 10, 30, 00),
                Comment = "Start new",
                Count = 4
            };
            var quantCollection = new Quants(factory);

            //Act
            quantCollection.Create(quantTrue);
            var quant = quantCollection.ReadSingle(d => d.Comment == "Start new");
            Assert.IsNotNull(quant);
            quantCollection.Delete(quant);
            quant = quantCollection.ReadSingle(d => d.Comment == "Start new");

            //Assert
            Assert.IsNull(quant);

        }


        [Test]
        public void GetQuantByDate()
        {
            //Arrange
            var Today = new DateTime(2017, 3, 25);
            var quant1 = new Quant() { Time = new DateTime(2017, 3, 24, 10, 30, 00) };
            var quant2 = new Quant() { Time = new DateTime(2017, 3, 24, 12, 30, 00) };
            var quantIncorrect = new Quant() { Time = Today };

            var quantCollection = new Quants(factory);
            quantCollection.Create(quantIncorrect);
            quantCollection.Create(quant2);
            quantCollection.Create(quant1);

            //Act
            var list = quantCollection.Read(new DateTime(2017, 3, 24));

            //Assert

            Assert.IsTrue(list is List<Quant>);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(quant1.Time, list[0].Time);
            Assert.AreEqual(quant2.Time, list[1].Time);
        }

        [Test]
        public void GetQuantByWeek()
        {
            //Arrange
            var quantCollection = new Quants(factory);
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
            quantCollection.Create(quant8week);
            quantCollection.Create(quant9week);

            //Act
            var list = quantCollection.Read(9, 2017);

            //Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(quant9week.Time, list[0].Time);
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
                ID = 100,
                Comment = oldComment,
                Time = today
            };
            var quantCollection = new Quants(factory);
            quantCollection.Create(quant);

            //Act
            var changedQuant = quantCollection.ReadSingle(d => d.Time == today);
            changedQuant.Comment = newComment;
            quantCollection.Update(changedQuant);
            quant = quantCollection.ReadSingle(d => d.Time == today);

            //Assert
            Assert.AreEqual(newComment, quant.Comment);
        }
    }
}

