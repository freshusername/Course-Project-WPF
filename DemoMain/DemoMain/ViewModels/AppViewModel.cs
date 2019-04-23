using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using DemoMain.Models;
using System.Data;
using System.Windows;

namespace DemoMain.ViewModels
{
    class AppViewModel
    {
        // connection string
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\course 2\1.C#\ProjectWPF\Course-Project-WPF\DemoMain\DemoMain\CarsDB.mdf;Integrated Security=True";

        public Car ActiveCar { get; private set; }
        public List<Car> CatalogCars { get; } = new List<Car>();

        // this method provides initial data for application
        public void PreloadCars(Image leftBtn, Image rightBtn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter($"select * from Cars", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    Car loadCar = new Car(
                        row.Field<string>("Name"),
                        row.Field<string>("Model"),
                        row.Field<string>("Transmission"),
                        row.Field<string>("GazType"),
                        row.Field<float>("EngineLitres"),
                        row.Field<string>("TypeOfCar"),
                        row.Field<float>("Price"),
                        row.Field<string>("Photos"),
                        row.Field<int>("Discount")
                        )
                    {
                        carDiscount = row.Field<int>("Discount")
                    };
                    CatalogCars.Add(loadCar);
                }

                ActiveCar = CatalogCars.FirstOrDefault();
                if (CatalogCars.Count > 1)
                {
                    rightBtn.Visibility = Visibility.Visible;
                    leftBtn.Visibility = Visibility.Hidden;
                }
                else if (CatalogCars.Count <= 1)
                {
                    leftBtn.Visibility = Visibility.Hidden;
                    rightBtn.Visibility = Visibility.Hidden;
                }
            }
        }

        // inserting new offer
        public void AddCar(string carName, string carModel, string carTransmission, string carGazType, float carEngineLitres, string carTypeOfCar, int carDiscount, string carImgPath, float carPrice, TextBlock carNameLabel, TextBlock carModelLabel, TextBlock carTransmissionLabel, TextBlock carGazTypeLabel, TextBlock carEngineLitresLabel,TextBlock carTypeOfCarLabel, TextBlock carDiscountLabel, TextBlock priceLabel, Image rightBtn, Image leftBtn, StackPanel catalog, Label noOffersLabel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select * from Cars", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                DataRow row = set.Tables[0].NewRow();

                Car car = new Car( carName, carModel, carTransmission, carGazType,carEngineLitres, carTypeOfCar, carPrice, carImgPath, carDiscount);

                row[1] = car.carName;
                row[2] = car.carModel;
                row[3] = car.carTransmission;
                row[4] = car.carGazType;
                row[5] = car.carEngineLitres;
                row[6] = car.carTypeOfCar;
                row[8] = car.carDiscount;
                row[9] = car.carImgPath;
                row[10] = car.carPrice;


                set.Tables[0].Rows.Add(row);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Update(set);

                CatalogCars.Add(car);

                ActiveCar = car;

                carNameLabel.Text = ActiveCar.carName;
                carModelLabel.Text = ActiveCar.carModel;
                carTransmissionLabel.Text = ActiveCar.carTransmission;
                carEngineLitresLabel.Text = ActiveCar.carEngineLitres.ToString();
                carTypeOfCarLabel.Text = ActiveCar.carTypeOfCar;
                carGazTypeLabel.Text = ActiveCar.carGazType;
                carDiscountLabel.Text = ActiveCar.carDiscount.ToString();
                priceLabel.Text = ActiveCar.carPrice.ToString();

                if (CatalogCars.Count > 1)
                {
                    rightBtn.Visibility = Visibility.Hidden;
                    leftBtn.Visibility = Visibility.Visible;
                }
                else if (CatalogCars.Count <= 1)
                {
                    leftBtn.Visibility = Visibility.Hidden;
                    rightBtn.Visibility = Visibility.Hidden;
                }
                catalog.Visibility = Visibility.Visible;
                noOffersLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
