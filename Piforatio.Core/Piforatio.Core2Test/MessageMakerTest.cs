
using Piforatio.WPF;
using NUnit.Framework;

namespace Piforatio.Core2Test
{
    [TestFixture]
    class MessageMakerTest
    {
        [Test]
        public void CreateMessageMaker()
        {
            //Arrange
            MessageMaker maker = new MessageMaker();

            //Act, Assert
            Assert.AreEqual("Hello, user!", maker.Message);
        }

        [Test]
        public void SendMessage()
        {
            //Arrange
            MessageMaker maker = new MessageMaker();
            string outMessage = "";
            maker.PropertyChanged += (obj, args) =>
            {
                outMessage = maker.Message;
            };

            //Act
            maker.Send("Hello world");

            //Assert
            Assert.AreEqual("Hello world", outMessage);
        }
    }
}
