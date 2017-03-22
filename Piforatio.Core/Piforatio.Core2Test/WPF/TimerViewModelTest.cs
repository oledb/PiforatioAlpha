using Piforatio.WPF;
using NUnit.Framework;

namespace Piforatio.Core2Test.WPF
{
    [TestFixture]
    class TimerViewModelTest
    {
        [Test]
        public void CreateTimerViewModel()
        {
            //Arrange, Act
            TimerViewModel timer = new TimerViewModel();

            //Assert
            Assert.AreEqual("0000", timer.EndYear);
        }
    }
}
