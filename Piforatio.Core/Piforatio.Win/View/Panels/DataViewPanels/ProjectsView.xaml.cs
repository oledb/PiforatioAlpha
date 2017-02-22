using System.Windows;
using System.Windows.Controls;
using Piforatio.Win.View.Panels.DataViewPanels;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;
using System.Windows.Input;
using static System.String;
using System;

namespace Piforatio.Win.View.Panels.DataViewPanels
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private int selectedProjectEmptyValue = -1;

        private ProjectVMCollection _projectVMCollection;

        private IProject newProject = null;

        public ProjectsView(ProjectVMCollection projectVMCollection)
        {
            InitializeComponent();
            _projectVMCollection = projectVMCollection;
            DataContext = _projectVMCollection;    
        }

        private static RoutedUICommand _AddNewProject = new RoutedUICommand("Add new project", "_AddNewProject", typeof(UserControl));
        private static RoutedCommand _SaveNewProject = new RoutedCommand("Save new project",  typeof(UserControl));
        private static RoutedCommand _CancelNewProject = new RoutedCommand("Cancel new project",  typeof(UserControl));

        public static RoutedUICommand AddNewProject
        {
            get { return _AddNewProject; }
        }

        public static RoutedCommand SaveNewProject
        {
            get { return _SaveNewProject; }
        }

        public static RoutedCommand CancelNewProject
        {
            get { return _CancelNewProject; }
        }

        private void AddNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            _projectVMCollection.SelectProjectByValue = selectedProjectEmptyValue;
            newProject = new ProjectVM();
            clearSelectedProjectInputs();
        }

        private void AddNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = (newProject == null);
        }

        private void SaveNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            newProject.Name = nameTextBox.Text;
            newProject.Description = aimTextBox.Text;
            newProject.CreationTime = DateTime.Now;
            _projectVMCollection.AddProject(newProject);
            cancelNewProject();
        }

        private void SaveNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = newProject != null && !IsNullOrEmpty(nameTextBox.Text) && !IsNullOrEmpty(aimTextBox.Text);
        }

        private void CancelNewProject_Execute(object sender, ExecutedRoutedEventArgs args)
        {
            cancelNewProject();
            if (_projectVMCollection.Projects.Count > 0)
                _projectVMCollection.SelectProjectByValue = 0;
            else
                clearSelectedProjectInputs();
        }

        private void CancelNewProject_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = newProject != null;
        }

        private void projectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cancelNewProject();
        }

        private void cancelNewProject()
        {
            newProject = null;
        }

        private void clearSelectedProjectInputs()
        {
            nameTextBox.Text = "";
            aimTextBox.Text = "";
        }
    }
}
