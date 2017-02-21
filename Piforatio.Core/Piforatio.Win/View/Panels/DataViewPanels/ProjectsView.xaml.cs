using System.Windows;
using System.Windows.Controls;
using Piforatio.Win.View.Panels.DataViewPanels;
using Piforatio.Core.DataModel;
using Piforatio.Core.ObjectsAbstract;
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;

namespace Piforatio.Win.View.Panels.DataViewPanels
{
    /// <summary>
    /// Interaction logic for ProjectsView.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private ProjectVMCollection _projectVMCollection;
        public ProjectsView(ProjectVMCollection projectVMCollection)
        {
            InitializeComponent();
            _projectVMCollection = projectVMCollection;
            DataContext = _projectVMCollection;
            
        }
    }
}
