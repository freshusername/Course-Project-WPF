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

            coreAppWindow.LoadFromAcc(user.Login, user.Email, user.Password, user.IsAdmin);

            coreAppWindow.Show();

            LoginWindow.Close();
        }
    }
}
