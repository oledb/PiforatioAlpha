namespace Piforatio.Core2
{
    public class SoundPlayer
    {
        private ISound _sound;
        private IFileSystem _fileSystem;
        public SoundPlayer(ISound sound, IFileSystem fileSystem)
        {
            _sound = sound;
            _fileSystem = fileSystem;
        }

        public void Play(string sound)
        {
            var files = _fileSystem.GetFiles();
            _sound.PlaySound(files[sound]);
        }

        
    }
}
