using System.Media;
using System.IO;

namespace Piforatio.WPF
{
    public static class Player
    {
        public static void Play(string filename)
        {
            if (!File.Exists(filename)) return;
            using (var player = new SoundPlayer(filename))
                player.Play();
        }
    }
}
