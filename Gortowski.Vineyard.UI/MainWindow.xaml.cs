using Gortowski.Vineyard.UI.Bootstrap;
using Gortowski.Vineyard.UI.ViewModel;
using System.Windows;
using System.Linq;
using Ninject;

namespace Gortowski.Vineyard.UI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = KernelMain.KernelInstance.Get<MainViewModel>();
        }
    }
}
