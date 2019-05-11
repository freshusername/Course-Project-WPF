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
using DemoMain.GetCar_BuilderPattern;
using DemoMain.Model;



namespace DemoMain
{
    /// <summary>
    /// Логика взаимодействия для VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        //private AppViewModel viewModel = new AppViewModel();
        //private User activeUser;
        //private List<string> canvasNames = new List<string>() { "CatalogCanvas" };
        
        public VehiclesPage()
        {
            InitializeComponent();

            LstVwCars.Items.Clear();           
            var carsList = Cars.getCars();
            LstVwCars.ItemsSource = carsList;

            CarBuilder carBuilder = new CarBuilder();
            //carBuilder.getVehicleInfo();




        }
        private void AddTreeNode()
        {
            CarsDBEntities context = new CarsDBEntities();

            var test = context.CarManufacturer
                .Where(a => a.Id != 0)
                .Select(a => a.Id)
                .ToList();
            var test1 = context.Cars
                .Where(a => a.CarManufacturerId != 0)
                .Select(a => a.CarManufacturerId)
                .ToList();
        }
        //public static void addCar()
        //{
        //    CarBuilder builder = new CarBuilder();
        //    builder.getVehicleInfo("A6");
        //    builder.GetVehicle();
        //    MessageBox.Show(builder.GetVehicle().ToString());
        //}

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                //Do your stuff
                //string s = item.ToString();
                //MessageBox.Show(s);
                IVehicleBuilder builder = new CarBuilder();
                builder.getVehicleInfo(item.Content.ToString());

                txtCarManuf.Text = builder.GetVehicle().Name;
                txtCarModel.Text = builder.GetVehicle().Model;
                txtCarTransmission.Text = builder.GetVehicle().Transmission;
                txtCarGazType.Text = builder.GetVehicle().GazType;
                txtEngineLitres.Text = builder.GetVehicle().EngineLitres.ToString();
                txtPrice.Text = builder.GetVehicle().Price.ToString();
                txtTypeOfCar.Text = builder.GetVehicle().TypeOfCar;


                Uri imageUri1 = new Uri(builder.GetVehicle().Photo2, UriKind.RelativeOrAbsolute);
                BitmapImage imageBitmap1 = new BitmapImage(imageUri1);
                imgCar.Source = imageBitmap1;


            }
        }

    }
}
