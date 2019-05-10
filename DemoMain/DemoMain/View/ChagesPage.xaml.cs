using DemoMain.DbGetData_Singleton;
using DemoMain.View.ChangesPage_MVVM.ViewModel;
using Microsoft.Win32;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DemoMain.View.ChangesPage_MVVM.ViewModel;

namespace DemoMain
{
    /// <summary>
    /// Логика взаимодействия для ChagesPage.xaml
    /// </summary>
    public partial class ChagesPage : Page
    {
<<<<<<< HEAD
        public Accounts CurrentUser = new Accounts();
=======
        Accounts CurrentUser = new Accounts();
>>>>>>> 9726b1159f449f6c1d7f54b4200918f9af6298ee
        public ChagesPage()
        {
            InitializeComponent();
            fill_combobox();
        }


        private void fill_combobox()
        {
            CarsDBEntities context = new CarsDBEntities();
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
            CarsDBEntities context = new CarsDBEntities();

            if (CarNameComboBox.SelectedItem == null || txtCarsDiscount.Text == " " || txtCarsEngineLitres.Text == " " ||
                txtCarsGazType.Text == "" || txtCarsModel.Text == "" || txtCarsPhoto1.Text == "" || txtCarsTransmission.Text == "" ||
                txtCarsTypeOfCar.Text == "" || txtCarsPhoto2.Text == "" || txtCarsPhoto3.Text == "")
            {
                MessageBox.Show("Input data is empty!");
            }
            else
            {


                SingletonDb sig = SingletonDb.getInstance();
                sig.addCarToDb(CarNameComboBox.SelectedItem.ToString(), txtCarsModel.Text, txtCarsTransmission.Text, txtCarsGazType.Text, double.Parse(txtCarsEngineLitres.Text), txtCarsTypeOfCar.Text, int.Parse(txtCarsDiscount.Text), txtCarsPhoto1.Text, double.Parse(txtCarPrice.Text), txtCarsPhoto2.Text, txtCarsPhoto3.Text);


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
            CarsDBEntities context = new CarsDBEntities();

            Accounts user = context.Accounts
                .Where(l => l.Login == txtGetLogin.Text)
                .FirstOrDefault();
            context.Accounts.Remove(user);
            context.SaveChanges();

            MessageBox.Show("User has being deleted!");

            Accountsdtgr.Items.Refresh();

        }
        private void deleteUser()
        {
            using (CarsDBEntities1 context = new CarsDBEntities1())
            {
                Accounts user = context.Accounts.Find(CurrentUser.Login);
                context.Accounts.Remove(user);//error
                context.SaveChanges();
            }
            
            
        }

        private void Accountsdtgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

        }

        private void BtnOpenPh1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtCarsPhoto1.Text = openFileDialog.FileName;
                btnOpenPh1.Content = txtCarsPhoto1.Text;
            }
        }

        private void BtnOpenPh2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtCarsPhoto2.Text = openFileDialog.FileName;
                btnOpenPh2.Content = txtCarsPhoto2.Text;
            }
        }

        private void BtnOpenPh3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtCarsPhoto3.Text = openFileDialog.FileName;
                btnOpenPh3.Content = txtCarsPhoto3.Text;
            }
        }
    }
}

