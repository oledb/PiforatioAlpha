using static System.Math;
using static System.Convert;

namespace Piforatio.Core2
{
    public static class AlarmclockFormatExtentsion
    {
        public static int ToMinutes(this double total)
        {
            return ToInt32(Truncate(total / 60)) % 60;
        }

        public static int ToHours(this double total)
        {
            return ToInt32(Truncate(total / 3600));
        }

        public static int ToSeconds(this double total)
        {
            return ToInt32(total) % 60;
        }

        public static string ToTimerFormat(this double total)
        {
            total = Truncate(total);
            return $"{total.ToHours().ToDigit()}:{total.ToMinutes().ToDigit()}:{total.ToSeconds().ToDigit()}";
        }

        private static string ToDigit(this int value)
        {
            var temp = value.ToString();
            if (temp.Length == 1)
                temp = "0" + temp;
            return temp;
        }
    }
}