using System;
using System.Windows;
using System.Windows.Input;
using System.Timers;

namespace Piforatio.WPF
{
    public partial class MainWindow : Window
    {
        private TimerViewModel timerViewModel;
        private const char playChar = '\uF04B';
        private const char stopChar = '\uF04D';
        private const char pauseChar = '\uF04C';
        private Timer timer;

        public MainWindow()
        {  
            InitializeComponent();
            initializeTimer();
        }

        private void initializeTimer()
        {
            timerViewModel = new TimerViewModel(new MyDateTime());
            timerLabel.DataContext = timerViewModel;
            timer = new Timer(100);
            timer.Elapsed += (obj, args) => timerViewModel.Execute();
            timerViewModel.OnTimerEnd += (obj, args) =>
            {
                timer.Stop();
                Dispatcher.Invoke( () => playButton.Content = playChar.ToString());
            };
            timerViewModel.OnIntervalReached += (obj, args) => MessageBox.Show("hello");
        }

        private void StartAndPauseCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            string symbol = (string)playButton.Content;
            if (symbol[0] == playChar)
            {
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
