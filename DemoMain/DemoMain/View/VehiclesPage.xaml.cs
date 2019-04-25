using DemoMain.Models;
using DemoMain.ViewModels;
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

namespace DemoMain
{
    /// <summary>
    /// Логика взаимодействия для VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        private AppViewModel viewModel = new AppViewModel();
        private User activeUser;
        private List<string> canvasNames = new List<string>() { "CatalogCanvas" };
        public void LoadFromAcc(string login, string email, string password, bool IsAdmin)
        {
            activeUser = User.GetInstance(login, email, password, IsAdmin);

            viewModel.PreloadCars(PrevCarsBtn, NextCarsBtn);

            if (viewModel.CatalogCars.Count > 0)
            {
                CatalogCarsGrid.Visibility = Visibility.Visible;

                txtNameAuto1.Text = viewModel.ActiveCar.carName;
                txtTransmission1.Text = viewModel.ActiveCar.carTransmission;
                txtTypeOfGaz.Text = viewModel.ActiveCar.carGazType;
                txtDoors1.Text = viewModel.ActiveCar.carTypeOfCar;

                //for (var i = 0; i < viewModel.CatalogCars.Count; i++)
                //{
                //    txtDoors1.Text = viewModel.CatalogCars[i].carName ;
                    

                //}

                //will be created soon...
                //if (viewModel.ActiveCar.carDiscount > 0)
                //{
                //    txtPrice.Content = $"Price(-{viewModel.ActiveCar.carDiscount}%) :";
                //}
                //txtPrice.Content = viewModel.ActiveCar.carPrice;
            }
            else
                NoCarsLabel.Visibility = Visibility.Visible;
        }
        public VehiclesPage()
        {
            InitializeComponent();
        }
    }
}
