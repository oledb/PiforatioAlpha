using System.Windows;

namespace Piforatio.WPF
{
    public partial class MainWindow : Window
    {
        private TimerViewModel timerViewModel;
        public MainWindow()
        {
            timerViewModel = new TimerViewModel(new MyDateTime());
            InitializeComponent();
            timerLabel.DataContext = timerViewModel;
        }
    }
}
