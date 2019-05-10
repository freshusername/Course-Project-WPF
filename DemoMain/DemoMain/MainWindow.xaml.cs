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
using System.Diagnostics;
using DemoMain.Models;
using DemoMain.ViewModels;
using DemoMain;




namespace DemoMain
{



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private AppViewModel viewModel = new AppViewModel();
        //private User activeUser;
        //private List<string> canvasNames = new List<string>() { "CatalogCanvas" };


        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        private void ItemOpenGithub_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

       
        private void ItemVehicles_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new VehiclesPage();
        }

        private void ItemHome_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new HomePage();

        }

        private void ItemDillers_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new DillersPage();

        }

        private void ItemCallUs_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new CallUsPage();

        }


        private void ItemChanges_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new ChagesPage();

        }
        

        
    }
}