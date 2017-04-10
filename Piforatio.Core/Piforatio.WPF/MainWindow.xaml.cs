using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Piforatio.WPF
{
    public partial class MainWindow
    {
        private TimerViewModel _timerViewModel;
        private MessageSender _messageMaker;
        private TimerMessager _timerMessager;
        private const char PlayChar = '\uF04B';
        private const char PauseChar = '\uF04C';
        private Timer _timer;

        public MainWindow()
        {  
            InitializeComponent();
            InitializeTimer();
            InitializeMessageMaker();
        }

        private void InitializeTimer()
        {
            _timerViewModel = new TimerViewModel(new MyDateTime());
            timerLabel.DataContext = _timerViewModel;
            _timer = new Timer(100);
            _timer.Elapsed += (obj, args) => _timerViewModel.Execute();
            _timerViewModel.OnTimerStop += (obj, args) =>
                Dispatcher.Invoke(StopTimer);
            _timerViewModel.OnIntervalReached += (obj, args) => Player.Play(PlayerSounds.Interval);
        }

        private void InitializeMessageMaker()
        {
            _messageMaker = new MessageSender();
            InfoLabel.DataContext = _messageMaker;
            _timerMessager = new TimerMessager(_messageMaker, _timerViewModel);
        }

        private void StartAndPauseCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {   
            var symbol = (string)playButton.Content;
            if (symbol[0] == PlayChar)
            {
                Player.Play(PlayerSounds.Start);
                playButton.Content = PauseChar.ToString();
                _timerViewModel.Start();
                _timer.Start();
            }
            else
            {
                playButton.Content = PlayChar.ToString();
                _timerViewModel.Pause();
            }
        }

        private void StopTimer()
        {
            Player.Play(PlayerSounds.Stop);
            playButton.Content = PlayChar.ToString();
            _timer.Stop();
        }

        private void StopCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            _timerViewModel.Stop();
        }

        private void StopCommand_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = _timerViewModel?.IsStarted ?? false;
        }

        public static RoutedUICommand StartAndPauseCommand { get; } = new RoutedUICommand("", "StartAndPause", typeof(Window));

        public static RoutedUICommand StopCommand { get; } = new RoutedUICommand("", "StartAndPause", typeof(Window));
    }
}
