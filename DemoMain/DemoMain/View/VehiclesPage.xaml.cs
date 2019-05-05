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
using DemoMain.EF;

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
        }
        private void AddTreeNode()
        {
            CarsDBEntities1 context = new CarsDBEntities1();

            var test = context.CarManufacturer
                .Where(a => a.Id != 0)
                .Select(a => a.Id)
                .ToList();
            var test1 = context.Cars
                .Where(a => a.CarManufacturerId != 0)
                .Select(a => a.CarManufacturerId)
                .ToList();
        }
    }
}
