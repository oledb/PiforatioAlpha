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

namespace Piforatio.Win.View.Panels.DataViewPanels
{
    /// <summary>
    /// Interaction logic for PlanView.xaml
    /// </summary>
    public partial class PlanView : UserControl
    {
        public PlanView()
        {
            InitializeComponent();
            calendar.SelectedDate = new DateTime(2017, 2, 10);
        }
    }
}
