using GalaSoft.MvvmLight.Ioc;
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

namespace FootballEstimate
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        internal void CreateTab(object viewModel)
        {
            var tabItem = new TabItem();
            tabItem.Content = new View.SeasonControl();
            tabItem.DataContext = viewModel;
            int index = this.tabControl.Items.Add(tabItem);
            this.tabControl.SelectedIndex = index;
            
        }
    }
}
