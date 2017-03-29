using System.Media;

namespace Piforatio.WPF
{
    public static class Player
    {
        public static void Play(string filename)
        {
            using (var player = new SoundPlayer(filename))
                player.Play();
        }
    }
}
