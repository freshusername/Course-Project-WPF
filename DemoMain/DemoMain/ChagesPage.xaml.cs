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
    /// Логика взаимодействия для ChagesPage.xaml
    /// </summary>
    public partial class ChagesPage : Page
    {
        public ChagesPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //        private readonly LoginViewModel viewModel = new LoginViewModel();
            //    private User activeUser;
            //    //private List<string> canvasNames = new List<string>() { "CatalogCanvas" };

            //    public void LoadFromAccount(string login, string email, string password, bool IsAdmin)
            //    {
            //        activeUser = User.GetInstance(login, email, password, IsAdmin);

            //        viewModel.PreloadCars(SlideLeftButton, SlideRightButton);

            //        if (viewModel.CatalogOffers.Count > 0)
            //        {
            //            CatalogCanvas.Visibility = Visibility.Visible;

            //            AddressValue.Content = viewModel.activeUser.Address;
            //            OwnerNameValue.Content = viewModel.activeUserr.Owner;
            //            EmailValue.Content = viewModel.activeUser.Email;
            //            PhoneValue.Content = viewModel.activeUser.PhoneNumber;
            //            SquareValue.Content = viewModel.activeUser.SquareFeet;
            //            if (viewModel.ActiveOffer.Discount > 0)
            //            {
            //                PriceLabel.Content = $"Price(-{viewModel.activeUser.Discount}%) :";
            //            }
            //            PriceValue.Content = viewModel.activeUser.Price;
            //        }
            //        else
            //            NoOffersLabel.Visibility = Visibility.Visible;
            //    }
            //}
        }
    }
}
