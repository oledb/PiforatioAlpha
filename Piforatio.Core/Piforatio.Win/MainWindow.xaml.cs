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
using Piforatio.Win.ViewModelCollection;
using Piforatio.Win.ViewModel;
using Piforatio.Win.Fakes;
using Piforatio.Core.DataModel;
using Moq;

namespace Piforatio.Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectVMCollection _projectVMCollection;
        public MainWindow()
        {
            InitializeComponent();
            var context = new DataContextMock(true);
            var contextFactory = new Mock<IDataContextFactory>();
            contextFactory.Setup(cf => cf.CreateContext())
                .Returns(context);
            var vm = new ProjectModel(contextFactory.Object);
            _projectVMCollection = new ProjectVMCollection(vm);
            DataContext = _projectVMCollection;
        }
    }
}
