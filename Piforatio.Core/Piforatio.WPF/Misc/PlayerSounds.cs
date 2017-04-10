using System;
using System.IO;

namespace Piforatio.WPF
{
    public struct PlayerSounds
    {
        private static string CombineAppPath(string filename) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

        public static string Start => CombineAppPath("Start.wav");

        public static string Stop => CombineAppPath("Stop.wav");

        public static string Interval => CombineAppPath("Interval.wav");
    }
}
