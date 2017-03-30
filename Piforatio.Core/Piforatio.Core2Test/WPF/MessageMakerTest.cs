
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
            MessageSender maker = new MessageSender();

            //Act, Assert
            Assert.AreEqual("Hello, user!", maker.Message);
        }

        [Test]
        public void SendMessage()
        {
            //Arrange
            MessageSender maker = new MessageSender();
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
