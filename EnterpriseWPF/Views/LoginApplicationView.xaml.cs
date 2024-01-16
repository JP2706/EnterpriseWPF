using EnterpriseWPF.ViewModels;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace EnterpriseWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginApplicationView.xaml
    /// </summary>
    public partial class LoginApplicationView : MetroWindow
    {
        public LoginApplicationView()
        {
            InitializeComponent();
            DataContext = new LoginApplicationViewModel();
        }

       
    }
}
