using System.Windows;
using System.Windows.Input;

namespace Piforatio.WPF
{
    public partial class MainWindow : Window
    {
        private TimerViewModel timerViewModel;
        private const char playChar = '\uF04B';
        private const char stopChar = '\uF04D';
        private const char pauseChar = '\uF04C';
        public MainWindow()
        {
            timerViewModel = new TimerViewModel(new MyDateTime());
            InitializeComponent();
            timerLabel.DataContext = timerViewModel;
        }

        private void StartAndPauseCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            string symbol = (string)playButton.Content;
            if (symbol[0] == playChar)
                playButton.Content = pauseChar.ToString();
            else
                playButton.Content = playChar.ToString();
        }

        private void StopCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            playButton.Content = playChar.ToString();
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
