using System;
using System.Windows.Controls;
using Piforatio.Win.View.Panels.DataViewPanels;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;
using System.Windows.Input;
using static System.String;

namespace Piforatio.Win.View.Panels.DataViewPanels
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private ProjectVMCollection _projectVMCollection;

        private object newProject;

        public ProjectsView(ProjectVMCollection projectVMCollection)
        {
            InitializeComponent();
            _projectVMCollection = projectVMCollection;
            DataContext = _projectVMCollection;    
        }

        public static RoutedUICommand AddNewProject = new RoutedUICommand("Add new project", "Add new project", typeof(UserControl));
        public static RoutedUICommand SaveNewProject = new RoutedUICommand("Save new project", "Save new project", typeof(UserControl));
        public static RoutedUICommand CancelNewProject = new RoutedUICommand("Cancel new project", "Cancel new project", typeof(UserControl));

        private void AddNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            newProject = new ProjectVM();
            _projectVMCollection.SelectProjectByValue = -1;
            nameTextBox.Text = "";
            aimTextBox.Text = "";
        }

        private void AddNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = newProject == null;
        }

        private void SaveNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void SaveNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = newProject != null && IsNullOrEmpty(nameTextBox.Text) && IsNullOrEmpty(aimTextBox.Text);
        }

        private void CancelNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {

        }

        private void CancelNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = newProject != null;
        }
    }
}
