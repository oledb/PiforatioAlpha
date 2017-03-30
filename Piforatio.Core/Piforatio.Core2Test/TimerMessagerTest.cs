using System;
using Piforatio.WPF;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace Piforatio.Core2Test
{
    [TestFixture]
    public class TimerMessagerTest
    {
        Mock<TimerViewModel> timerMock;
        Mock<MessageSender> senderMock;

        [SetUp]
        public void SetUp()
        {
            timerMock = new Mock<TimerViewModel>();
            senderMock = new Mock<MessageSender>();
            timerMock.Setup(t => t.Start())
                .Raises(t => t.OnTimerStart += null, new EventArgs());
            timerMock.Setup(t => t.Execute())
                .Raises(t => t.OnIntervalReached += null, new EventArgs());
            timerMock.Setup(t => t.Stop())
                .Raises(t => t.OnTimerStop += null, new EventArgs());
        }

        [Test]
        public void ShowMessageWhenTimerStart()
        {
            //Arrange
            var timer = timerMock.Object;
            var sender = senderMock.Object;
            TimerMessager messager = new TimerMessager(sender, timer);

            //Act
            timer.Start(); 

            //Assert
            senderMock.Verify(s => s.Send("Timer is started"));
        }

        [TestCase(3)]
        [TestCase(2)]
        public void ShowMessageWhenTimerStop(int quantCount)
        {
            //Arrange
            var timer = timerMock.Object;
            var sender = senderMock.Object;
            TimerMessager messager = new TimerMessager(sender, timer);

            //Act
            for (int i = 0; i < quantCount; i++)
                timer.Execute();
            timer.Stop();

            //Assert
            senderMock.Verify(s => s.Send($"{quantCount} quants was completed"));
        }

        [Test]
        public void ShowMessageWhenTimerStartAndStop()
        {
            //Arrange
            var timer = timerMock.Object;
            var sender = senderMock.Object;
            TimerMessager messager = new TimerMessager(sender, timer);

            //Act
            timer.Start();
            timer.Execute();
            timer.Stop();
            timer.Start();
            timer.Stop();

            //Assert
            senderMock.Verify(s => s.Send("No quants was completed"));
        }

        [Test]
        public void ShowMessageWhenTimeIsEnd()
        {
            //Arrange
            timerMock.Setup(t => t.Execute())
                .Raises(t => t.OnTimerEnd += null, new EventArgs());
            var timer = timerMock.Object;
            var sender = senderMock.Object;
            TimerMessager messager = new TimerMessager(sender, timer);

            //Act
            timer.Execute();

            //Assert
            senderMock.Verify(s => s.Send("No quants was completed"));
        }
    }
}
