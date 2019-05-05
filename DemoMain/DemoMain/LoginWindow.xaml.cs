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
            MainWindow coreAppWindow = new MainWindow();

            User user = viewModel.LoadUser(txtNickname.Text.Trim());

            coreAppWindow.Show();

            this.Close();
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

            txtRegPassword.LostFocus += TxtRegPasswActive_LostFocus;
            txtConfirmPassword.LostFocus += TxtConfirmPasswActive_LostFocus;

            txtNickname.Text = "Login";
            txtRegPassword.Clear();

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

        private void TxtRegPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtRegPassword.Visibility = Visibility.Hidden;
            txtRegPassword.Visibility = Visibility.Visible;
            txtRegPassword.Focus();
        }

        private void ConfirmPasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //ConfirmPasswordTextBox.Visibility = Visibility.Hidden;
            //ConfirmPasswActive.Visibility = Visibility.Visible;
            //ConfirmPasswActive.Focus();
        }

     

        private void ImgShowPassword_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtConfirmPassword.Password == txtRegPassword.Password)
                {
                    viewModel.InsertUser(User.GetInstance(txtRegUsername.Text, txtEmail.Text, txtRegPassword.Password, (bool)chBxAdminCheckBox.IsChecked));

                    RegisterPanel.Visibility = Visibility.Hidden;
                    LoginPanel.Visibility = Visibility.Visible;


                    txtNickname.Focus();
                }
                else if (txtConfirmPassword.Password != txtRegPassword.Password)
                {
                    MessageBox.Show("Passwords not equal!");
                }
            }
            catch (Exception)
            {
                
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
