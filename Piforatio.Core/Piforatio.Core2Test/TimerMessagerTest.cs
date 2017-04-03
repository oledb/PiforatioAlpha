using System;
using Moq;
using NUnit.Framework;
using Piforatio.WPF;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class TimerMessagerTest
    {
        private Mock<TimerViewModel> _timerMock;
        private Mock<MessageSender> _senderMock;

        [SetUp]
        public void SetUp()
        {
            _timerMock = new Mock<TimerViewModel>();
            _senderMock = new Mock<MessageSender>();
            _timerMock.Setup(t => t.Start())
                .Raises(t => t.OnTimerStart += null, new EventArgs());
            _timerMock.Setup(t => t.Execute())
                .Raises(t => t.OnIntervalReached += null, new EventArgs());
            _timerMock.Setup(t => t.Stop())
                .Raises(t => t.OnTimerStop += null, new EventArgs());
        }

        [Test]
        public void ShowMessageWhenTimerStart()
        {
            //Arrange
            var timer = _timerMock.Object;
            var sender = _senderMock.Object;
            var messager = new TimerMessager(sender, timer);

            //Act
            timer.Start(); 

            //Assert
            _senderMock.Verify(s => s.Send("Timer is started"));
        }

        [TestCase(3)]
        [TestCase(2)]
        public void ShowMessageWhenTimerStop(int quantCount)
        {
            //Arrange
            var timer = _timerMock.Object;
            var sender = _senderMock.Object;
            var messager = new TimerMessager(sender, timer);

            //Act
            for (int i = 0; i < quantCount; i++)
                timer.Execute();
            timer.Stop();

            //Assert
            _senderMock.Verify(s => s.Send($"{quantCount} quants was completed"));
        }

        [Test]
        public void ShowMessageWhenTimerStartAndStop()
        {
            //Arrange
            var timer = _timerMock.Object;
            var sender = _senderMock.Object;
            TimerMessager messager = new TimerMessager(sender, timer);

            //Act
            timer.Start();
            timer.Execute();
            timer.Stop();
            timer.Start();
            timer.Stop();

            //Assert
            _senderMock.Verify(s => s.Send("No quants was completed"));
        }

        [Test]
        public void ShowMessageWhenTimeIsEnd()
        {
            //Arrange
            _timerMock.Setup(t => t.Execute())
                .Raises(t => t.OnTimerEnd += null, new EventArgs());
            var timer = _timerMock.Object;
            var sender = _senderMock.Object;
            var messager = new TimerMessager(sender, timer);

            //Act
            timer.Execute();

            //Assert
            _senderMock.Verify(s => s.Send("No quants was completed"));
        }
    }
}
