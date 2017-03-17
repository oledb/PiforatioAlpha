using NUnit.Framework;
using Piforatio.Core2;
using System;

namespace Piforatio.Core2Test
{
    [TestFixture]
    class AlarmclockFormatTest
    {
        [TestCase(0d,0)]
        [TestCase(60d, 1)]
        public void ConvertSecondsToMinute(double seconds, int minute)
        {
            //Arrange,Act,Assert
            Assert.AreEqual(minute, seconds.ToMinute());
        }
    }
}
