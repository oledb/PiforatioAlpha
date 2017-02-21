using System.Windows;
using System.Windows.Controls;
using Piforatio.Win.View.Panels.DataViewPanels;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;
using System.Windows.Input;

namespace Piforatio.Win.View.Panels.DataViewPanels
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private ProjectVMCollection _projectVMCollection;

        private IProject newProject = null;

        public ProjectsView(ProjectVMCollection projectVMCollection)
        {
            InitializeComponent();
            _projectVMCollection = projectVMCollection;
            DataContext = _projectVMCollection;    
        }

        private RoutedUICommand AddNewProject = new RoutedUICommand("Add new project", "Add new project", typeof(UserControl));
        private RoutedUICommand SaveNewProject = new RoutedUICommand("Save new project", "Save new project", typeof(UserControl));
        private RoutedUICommand CancelNewProject = new RoutedUICommand("Cancel new project", "Cancel new project", typeof(UserControl));

        private void AddNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void AddNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        private void SaveNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void SaveNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }

        private void CancelNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void CancelNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {

        }
    }
}
