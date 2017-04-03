
using NUnit.Framework;
using Piforatio.WPF;

namespace Piforatio.Core2Test
{
    [TestFixture]
    internal class MessageMakerTest
    {
        [Test]
        public void CreateMessageMaker()
        {
            //Arrange
            var maker = new MessageSender();

            //Act, Assert
            Assert.AreEqual("Hello, user!", maker.Message);
        }

        [Test]
        public void SendMessage()
        {
            //Arrange
            var maker = new MessageSender();
            var outMessage = "";
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
