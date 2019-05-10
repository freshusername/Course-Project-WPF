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

using DemoMain.ViewModels;
using DemoMain.Models;
<<<<<<< HEAD
using DemoMain.DbGetData_Singleton;
=======
using DemoMain.EF;
>>>>>>> 9726b1159f449f6c1d7f54b4200918f9af6298ee

namespace DemoMain
{


    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private readonly LoginViewModel viewModel = new LoginViewModel();

        public LoginWindow()
        { 
            InitializeComponent();
        }

      
        private void BtnLogin_Click_1(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            SingletonDb sig = SingletonDb.getInstance();
            if(sig.loginAccount(txtNickname.Text, txtPassword.Password))
            {
                this.Close();
            }
=======
            MainWindow coreAppWindow = new MainWindow();

            //User user = viewModel.LoadUser(txtNickname.Text.Trim(), txtPassword.Password);
            CarsDBEntities1 context = new CarsDBEntities1();
            var user = context.Accounts
                .Where(u => u.Login == txtNickname.Text)
                .FirstOrDefault();
            txtNickname.Text = user.Login;
            if (user != null)
            {
                MessageBox.Show($"{user.Login} - {user.Password}");
                MessageBox.Show($"{txtNickname.Text} - {txtPassword.Password}");
                if (user.Password == txtPassword.Password)
                {
                    coreAppWindow.Show();
                    this.Close();
                }
                else { MessageBox.Show("wrong password"); }
            }
            else { MessageBox.Show("No such user!"); }
>>>>>>> 9726b1159f449f6c1d7f54b4200918f9af6298ee

        }

        private void CreateAccount_MouseMove(object sender, MouseEventArgs e)
        {
            CreateAccount.TextDecorations = TextDecorations.Underline;
        }

        private void CreateAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            CreateAccount.TextDecorations = null;

        }

        private void CreateAccount_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RegisterPanel.Visibility = Visibility.Visible;
            LoginPanel.Visibility = Visibility.Hidden;

            //txtRegPassword.LostFocus += TxtRegPasswActive_LostFocus;
            //txtConfirmPassword.LostFocus += TxtConfirmPasswActive_LostFocus;

            //txtNickname.Text = "Login";
            //txtRegPassword.Clear();

            txtRegUsername.Focus();
        }

      
        private void TxtRegUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtRegUsername.SelectAll();

        }

        private void TxtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEmail.SelectAll();

        }

       

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtConfirmPassword.Password == txtRegPassword.Password)
                {
<<<<<<< HEAD
                    SingletonDb sig = SingletonDb.getInstance();
                    if(sig.registerAccount(txtRegUsername.Text, txtEmail.Text, txtRegPassword.Password, (bool)chBxAdminCheckBox.IsChecked))
                    {
                        RegisterPanel.Visibility = Visibility.Hidden;
                        LoginPanel.Visibility = Visibility.Visible;
                        txtNickname.Focus();
                    }
                                        
=======
                    viewModel.InsertUser(Accounts.GetInstance(txtRegUsername.Text, txtEmail.Text, txtRegPassword.Password, (bool)chBxAdminCheckBox.IsChecked));

                    RegisterPanel.Visibility = Visibility.Hidden;
                    LoginPanel.Visibility = Visibility.Visible;


                    txtNickname.Focus();
>>>>>>> 9726b1159f449f6c1d7f54b4200918f9af6298ee
                }
                else if (txtConfirmPassword.Password != txtRegPassword.Password)
                {
                    MessageBox.Show("Passwords not equal!");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }
   

        private void LoginAccount_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LoginPanel.Visibility = Visibility.Visible;
            RegisterPanel.Visibility = Visibility.Hidden;

            //PasswActive.LostFocus -= PasswActive_LostFocus;
            //RegPasswActive.LostFocus += RegPasswActive_LostFocus;
            //ConfirmPasswActive.LostFocus += ConfirmPasswActive_LostFocus;

            txtNickname.Text = "Login";

            //txtNickname.Focus();
        }

        private void LoginAccount_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void LoginAccount_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void TxtRegPasswActive_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxtConfirmPasswActive_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxtConfirmPasswActive_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxtRegPasswActive_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SkipLogin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void SkipLogin_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void SkipLogin_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
