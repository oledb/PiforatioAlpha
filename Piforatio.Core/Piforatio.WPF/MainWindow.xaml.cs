
using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.IO;

namespace Piforatio.WPF
{
    public partial class MainWindow : Window
    {
        private TimerViewModel timerViewModel;
        private MessageSender messageMaker;
        private TimerMessager timerMessager;
        private const char playChar = '\uF04B';
        private const char stopChar = '\uF04D';
        private const char pauseChar = '\uF04C';
        private Timer timer;
        private const string soundsFolder = "D:\\Sounds";
        private string startSound = Path.Combine(soundsFolder, "Start.wav");
        private string stopSound = Path.Combine(soundsFolder, "Stop.wav");
        private string intervalSound = Path.Combine(soundsFolder, "Interval.wav");

        public MainWindow()
        {  
            InitializeComponent();
            initializeTimer();
            initializeMessageMaker();
        }

        private void initializeTimer()
        {
            timerViewModel = new TimerViewModel(new MyDateTime());
            timerLabel.DataContext = timerViewModel;
            timer = new Timer(100);
            timer.Elapsed += (obj, args) => timerViewModel.Execute();
            timerViewModel.OnTimerEnd += (obj, args) =>
                Dispatcher.Invoke( () => StopCommand_Execute(this, null));
            timerViewModel.OnIntervalReached += (obj, args) => Player.Play(intervalSound);
            timerViewModel.MaxPauseTime = 3;
        }

        private void initializeMessageMaker()
        {
            messageMaker = new MessageSender();
            infoLabel.DataContext = messageMaker;
            timerMessager = new TimerMessager(messageMaker, timerViewModel);
        }

        private void StartAndPauseCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {   
            string symbol = (string)playButton.Content;
            if (symbol[0] == playChar)
            {
                Player.Play(startSound);
                playButton.Content = pauseChar.ToString();
                timerViewModel.Start();
                timer.Start();
            }
            else
            {
                playButton.Content = playChar.ToString();
                timerViewModel.Pause();
            }
        }

        private void StopCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            if (timerViewModel.IsStarted)
                Player.Play(stopSound);
            playButton.Content = playChar.ToString();
            timerViewModel.Stop();
            timer.Stop();
        }

        private static RoutedUICommand _startAndPause = new RoutedUICommand("", "StartAndPause", typeof(Window));
        private static RoutedUICommand _stop = new RoutedUICommand("", "StartAndPause", typeof(Window));
        public static RoutedUICommand StartAndPauseCommand
        {
            get
            {
                return _startAndPause;
            }
        }

        public static RoutedUICommand StopCommand
        {
            get
            {
                return _stop;
            }
        }
    }
}
