using System.Windows;
using System.Windows.Input;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.Fakes;
using Piforatio.Core.DataModel;
using Piforatio.Win.View.Panels;
using Moq;

namespace Piforatio.Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectVMCollection _projectVMCollection;

        private DataView dataView;
        private TimerView timerView;
        private SettingsView settingsView;
        public MainWindow()
        {
            InitializeComponent();
            dataView = new DataView();
            timerView = new TimerView();
            settingsView = new SettingsView();
            mainGridPanel.Children.Add(dataView);
            menuNavBar.Visibility = Visibility.Collapsed;
        }

        private void CreateViewModels()
        {
            var context = new DataContextMock(true);
            var contextFactory = new Mock<IDataContextFactory>();
            contextFactory.Setup(cf => cf.CreateContext())
                .Returns(context);
            var vm = new ProjectModel(contextFactory.Object);
            _projectVMCollection = new ProjectVMCollection(vm);
            DataContext = _projectVMCollection;
        }

        /* Events */
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void menuGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainGridPanel.Children.Clear();
            string content = ((dynamic)sender).Content.ToString();
            if (content == "Timer")
                mainGridPanel.Children.Add(timerView);
            else if (content == "Data")
                mainGridPanel.Children.Add(dataView);
            else
                mainGridPanel.Children.Add(settingsView);
            MainMenuToggleCommand_Execute(sender, null);
        }

        /* Commands Events */
        bool isMenuVisiable = false;
        private void MainMenuToggleCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            if (isMenuVisiable)
                menuNavBar.Visibility = Visibility.Collapsed;
            else
                menuNavBar.Visibility = Visibility.Visible;
            isMenuVisiable = !isMenuVisiable;
        }

        private void MainMenuButtonsCommand_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            mainGridPanel.Children.Clear();
            if (args.Parameter.ToString() == "timer")
                mainGridPanel.Children.Add(timerView);
            else if (args.Parameter.ToString() == "data")
                mainGridPanel.Children.Add(dataView);
            else
                mainGridPanel.Children.Add(settingsView);
        }
    }

    public class MainWindowCommands
    {
        public readonly static RoutedUICommand MainMenuToggleCommand;
        public readonly static RoutedUICommand MainMenuButtonsCommand;

        static MainWindowCommands()
        {
            MainMenuToggleCommand = new RoutedUICommand("Press to show menu",
                "Main Menu", typeof(MainWindowCommands), new InputGestureCollection()
                {
                    new KeyGesture(Key.M,ModifierKeys.Alt)
                });

            MainMenuButtonsCommand = new RoutedUICommand("Press to chouse menu item",
                "Item elements", typeof(MainWindowCommands));
        }
    }
}
