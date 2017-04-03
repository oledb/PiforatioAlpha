using NUnit.Framework;
using Piforatio.Core2;

namespace Piforatio.Core2Test
{
    [TestFixture]
    internal class AlarmclockFormatTest
    {
        [TestCase(59d, 0)]
        [TestCase(3660, 1)]
        [TestCase(7200d, 0)]
        public void ConvertTotalSecondsToMinute(double total, int minutes)
        {
            //Arrange, Act, Assert
            Assert.AreEqual(minutes, total.ToMinutes());
        }

        [TestCase(3599d, 0)]
        [TestCase(3600d, 1)]
        [TestCase(7200d, 2)]
        public void ConvertTotalSecondsToHour(double total, int hours)
        {
            //Arrange, Act, Assert
            Assert.AreEqual(hours, total.ToHours());
        }

        [TestCase(59d, 59)]
        [TestCase(60d, 0)]
        [TestCase(61d, 1)]
        public void ConvertTotalSecondsToSeconds(double total, int seconds)
        {
            //Arrange, Act, Assert
            Assert.AreEqual(seconds, total.ToSeconds());
        }

        [TestCase(59d, "00:00:59")]
        [TestCase(119.7d, "00:01:59")]
        [TestCase(119d, "00:01:59")]
        public void ConvertTotalSecodsToTimerString(double total, string format)
        {
            //Arrange, Act
            var result = total.ToTimerFormat();

            //Assert
            Assert.AreEqual(format, result);
        }
    }
}