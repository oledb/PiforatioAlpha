using System;
using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class MainTest
    {
        [Test]
        public void AddNewQuant()
        {
            //Arrange
            var quant = new Quant()
            {
                Time = new DateTime(2017, 3, 3, 10, 30, 00),
                Project = "C# Books",
                Objective = "Piforatio - Logic",
                Count = 4
            };

            var quantCollection = new QuantCollection();

            //Act
            quantCollection.Add(quant);

            //Assert
            Assert.AreEqual(1, quantCollection.Length);
        }
    }
}
