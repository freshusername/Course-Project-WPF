using DemoMain.EF;
using DemoMain.View.ChangesPage_MVVM.ViewModel;
using Microsoft.Win32;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            fill_combobox();
        }



        private void fill_combobox()
        {
            CarsDBEntities1 context = new CarsDBEntities1();
            var test = context.CarManufacturer
                .Where(a => a.Id != 0)
                .Select(a => a.Name)
                .ToList();
            foreach (var item in test)
            {
                this.CarNameComboBox.Items.Add(item);
            }
        }
        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            CarsDBEntities1 context = new CarsDBEntities1();

            if (CarNameComboBox.SelectedItem == null || txtCarsDiscount.Text == " " || txtCarsEngineLitres.Text == " " ||
                txtCarsGazType.Text == "" || txtCarsModel.Text == "" || txtCarsPhotos.Text == "" || txtCarsTransmission.Text == "" ||
                txtCarsTypeOfCar.Text == "")
            {
                MessageBox.Show("Input data is empty!");
            }
            else
            {
                #region getCarManufacturerId
                string carManufName = CarNameComboBox.SelectedItem.ToString();

                var checkId = context.CarManufacturer
                    .Where(x => x.Name == carManufName)
                    .Select(x => new { Id = x.Id });

                int[] CarManufacturerId = new int[1];
                foreach (var item in checkId)
                {
                    CarManufacturerId[0] = item.Id;
                }

                #endregion

                if (checkId != null)
                {
                    Cars CarToAdd = new Cars
                    {
                        Name = carManufName,
                        Model = txtCarsModel.Text,
                        Transmission = txtCarsTransmission.Text,
                        GazType = txtCarsGazType.Text,
                        EngineLitres = double.Parse(txtCarsEngineLitres.Text),
                        TypeOfCar = txtCarsTypeOfCar.Text,
                        CarManufacturerId = CarManufacturerId[0],
                        Discount = int.Parse(txtCarsDiscount.Text),
                        Photos = txtCarsPhotos.Text,
                        Price = double.Parse(txtCarPrice.Text)
                    };
                    context.Cars.Add(CarToAdd);
                    MessageBox.Show(CarToAdd.ToString());
                    context.SaveChanges();
                }
                else { MessageBox.Show("No such Car manufacturer!"); }
            }


        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtCarsPhotos.Text = openFileDialog.FileName;
            }
        }


        private void RemCarbtn_Click(object sender, RoutedEventArgs e)
        {
            remCarPanel.Visibility = Visibility.Visible;
            addCarPanel.Visibility = Visibility.Hidden;
            mngUsersPanel.Visibility = Visibility.Hidden;
            mngUsersbtn.IsEnabled = true;
            addCarbtn.IsEnabled = true;
            remCarbtn.IsEnabled = false;
            //mngUsersPanel.DataContext = new RemCarViewModel();
        }

        private void AddCarbtn_Click(object sender, RoutedEventArgs e)
        {
            addCarPanel.Visibility = Visibility.Visible;
            mngUsersbtn.IsEnabled = true;
            addCarbtn.IsEnabled = false;
            remCarbtn.IsEnabled = true;
            addCarPanel.Visibility = Visibility.Visible;
            remCarPanel.Visibility = Visibility.Hidden;
            mngUsersPanel.Visibility = Visibility.Hidden;
            //mngUsersPanel.DataContext = new AddCarViewModel();
        }

        private void MngUsersbtn_Click(object sender, RoutedEventArgs e)
        {
            mngUsersPanel.DataContext = new AccountsViewModel();
            mngUsersbtn.IsEnabled = false;
            addCarbtn.IsEnabled = true;
            remCarbtn.IsEnabled = true;
            addCarPanel.Visibility = Visibility.Hidden;
            remCarPanel.Visibility = Visibility.Hidden;
            mngUsersPanel.Visibility = Visibility.Visible;


        }

        public string strLogin;
        private void BtnRemUserAccount_Click(object sender, RoutedEventArgs e)
        {
            CarsDBEntities1 context = new CarsDBEntities1();

            

            //Accounts acc = Accountsdtgr.SelectedItem as Accounts;

            //var test = context.Accounts.Where()
        }

        private void Accountsdtgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            
        }
    }
}

