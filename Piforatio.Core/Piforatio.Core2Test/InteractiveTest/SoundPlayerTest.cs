using NUnit.Framework;
using Piforatio.Core2;
using System;
using System.Collections.Generic;
using Moq;

namespace Piforatio.Core2Test
{
    [TestFixture]
    class SoundPlayerTest
    {
        private Mock<ISound> mockSound;
        private Mock<IFileSystem> mockFileSystem;

        [SetUp]
        public void CrateMocks()
        {
            mockSound = new Mock<ISound>();
            mockFileSystem = new Mock<IFileSystem>();
        }

        [Test]
        public void PlayErrorSound()
        {
            //Arrange
            var sound = mockSound.Object;
            var dictionary = new Dictionary<string, string>();
            dictionary["Error"] = "Error.wav";
            mockFileSystem.Setup(fs => fs.GetFiles())
                .Returns(dictionary);
            var fileSystem = mockFileSystem.Object;
            SoundPlayer player = new SoundPlayer(sound, fileSystem);

            //Act
            player.Play("Error");

            //Assert
            mockSound.Verify(p => p.PlaySound("Error.wav"));
        }
    }
}
