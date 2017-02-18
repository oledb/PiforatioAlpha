using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Piforatio.Win.View.Panels.DataViewPanels;

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
        public DataView()
        {
            InitializeComponent();
            projectView = new ProjectsView();
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
