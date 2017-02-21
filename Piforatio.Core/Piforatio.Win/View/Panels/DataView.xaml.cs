using System.Windows;
using System.Windows.Controls;
using Piforatio.Win.View.Panels.DataViewPanels;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;

namespace Piforatio.Win.View.Panels
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        private ProjectsView projectView;
        private TasksView tasksView;
        private PlanView planView;
        private ReportView reportView;

        private ProjectVMCollection _projectVMCollection;
        public DataView(ProjectVMCollection projectVMCollection)
        {
            InitializeComponent();
            //Dependency
            _projectVMCollection = projectVMCollection;

            //User Controls
            projectView = new ProjectsView(_projectVMCollection);
            tasksView = new TasksView();
            planView = new PlanView();
            reportView = new ReportView();

            toggleControlToDataGridPanel(projectView);
        }

        private void toggleControlToDataGridPanel(UserControl selectedControl)
        {
            dataGridPanel.Children.Clear();
            dataGridPanel.Children.Add(selectedControl);
        }

        private void projectButton_Click(object sender, RoutedEventArgs e)
        {
            toggleControlToDataGridPanel(projectView);
        }

        private void taskButton_Click(object sender, RoutedEventArgs e)
        {
            toggleControlToDataGridPanel(tasksView);
        }

        private void plansButton_Click(object sender, RoutedEventArgs e)
        {
            toggleControlToDataGridPanel(planView);
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            toggleControlToDataGridPanel(reportView);
        }
    }
}
