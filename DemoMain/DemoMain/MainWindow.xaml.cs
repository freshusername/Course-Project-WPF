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

namespace DemoMain
{



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel viewModel = new LoginViewModel();
        private User activeUser;
        //private List<string> canvasNames = new List<string>() { "CatalogCanvas" };

        public void LoadFromAccount(string login, string email, string password, bool IsAdmin)
        {
            activeUser = User.GetInstance(login, email, password, IsAdmin);

            viewModel.PreloadCars(SlideLeftButton, SlideRightButton);

            if (viewModel.CatalogOffers.Count > 0)
            {
                CatalogCanvas.Visibility = Visibility.Visible;

                AddressValue.Content = viewModel.ActiveOffer.Address;
                OwnerNameValue.Content = viewModel.ActiveOffer.Owner;
                EmailValue.Content = viewModel.ActiveOffer.Email;
                PhoneValue.Content = viewModel.ActiveOffer.PhoneNumber;
                SquareValue.Content = viewModel.ActiveOffer.SquareFeet;
                if (viewModel.ActiveOffer.Discount > 0)
                {
                    PriceLabel.Content = $"Price(-{viewModel.ActiveOffer.Discount}%) :";
                }
                PriceValue.Content = viewModel.ActiveOffer.Price;
            }
            else
                NoOffersLabel.Visibility = Visibility.Visible;
        }

        public MainWindow()
        {
            //MainFrame.Content = new LoginPage();
            //MainFrame.Content = new LogButtonPage();
            //InitializeDBCars dbCars = new InitializeDBCars();
            //dbCars.Initialize();
            //MessageBox.Show(dbCars.OKstr);
            //InitializeDBUsers dbUsers = new InitializeDBUsers();
            //dbUsers.Initialize();
            //MessageBox.Show(dbUsers.OKstr);
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
            string url = @"http://www.github.com";
            var startInfo = new ProcessStartInfo("chrome.exe", url);
            Process.Start(startInfo);
        }

        //private void ListViewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var item = sender as ListViewItem;
        //    if (item != null && item.IsSelected)
        //    {
        //        //Do your stuff
        //        MainFrame.Content = new VehiclesPage();
        //    }
        //}

        //private void ListViewMenu_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        //{
        //    var item = sender as ListViewItem;
        //    if (item != null && item.IsSelected)
        //    {
        //        //Do your stuff
        //        MainFrame.Content = new VehiclesPage();
        //    }
        //}

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

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LogButtonPage();
        }

        private void ItemChanges_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new ChagesPage();
        }
    }
}
