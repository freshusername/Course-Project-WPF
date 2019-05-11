using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DemoMain.View;
using DemoMain.Model;

namespace DemoMain.DbGetData_Singleton
{
    public class SingletonDb
    {
        private static SingletonDb instance;
        private SingletonDb() { }
        public static SingletonDb getInstance()
        {
            if (instance == null)
            {
                instance = new SingletonDb();
                return instance;
            }
            else { return instance; }
        }
        CarsDBEntities context = new CarsDBEntities();
        public bool loginAccount(string login, string password)
        {

            var test = context.Accounts
                .Where(a => a.Login == login && a.Password == password)
                .FirstOrDefault();
            if (test != null)
            {

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                return true;

            }
            else { MessageBox.Show("No such users!"); return false; }



        }



        //car
        Cars _car = new Cars();

        public void getVehicleInfo(string model)
        {

            var test = context.Cars
                .Where(c => c.Model == model)
                .Select(c => new
                {
                    name = c.Name,
                    model = c.Model,
                    transmission = c.Transmission,
                    gaztype = c.GazType,
                    enginelitres = c.EngineLitres,
                    typeofcar = c.TypeOfCar,
                    discount = c.Discount,
                    photo1 = c.Photo1,
                    price = c.Price,
                    photo2 = c.Photo2,
                    photo3 = c.Photo3
                });
            foreach (var c in test)
            {
                _car.Name = c.name;
                _car.Model = c.model;
                _car.Transmission = c.transmission;
                _car.GazType = c.gaztype;
                _car.EngineLitres = c.enginelitres;
                _car.TypeOfCar = c.typeofcar;
                _car.Discount = c.discount;
                _car.Photo1 = c.photo1;
                _car.Price = c.price;
                _car.Photo2 = c.photo2;
                _car.Photo3 = c.photo3;

            }

        }
        public Cars getVehicle()
        {
            return _car;
        }

        public void addCarToDb(string carName, string carModel, string carTransmission, string carGazType, double carEngLitres, string carType, int carDiscount, string carPhoto1, double carPrice, string carPhoto2, string carPhoto3)
        {
            #region getCarManufacturerId
            string carManufName = carName;

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
                Cars CarToAdd = new Cars();

                CarToAdd.Name = carManufName;
                CarToAdd.Model = carModel;
                CarToAdd.Transmission = carTransmission;
                CarToAdd.GazType = carGazType;
                CarToAdd.EngineLitres = carEngLitres;
                CarToAdd.TypeOfCar = carType;
                CarToAdd.CarManufacturerId = CarManufacturerId[0];
                CarToAdd.Discount = carDiscount;
                CarToAdd.Photo1 = carPhoto1;
                CarToAdd.Price = carPrice;
                CarToAdd.Photo2 = carPhoto2;
                CarToAdd.Photo3 = carPhoto3;

                context.Cars.Add(CarToAdd);
                context.SaveChanges();
                MessageBox.Show($"{CarToAdd.Name} \n {CarToAdd.Model} \n {CarToAdd.Transmission} \n {CarToAdd.GazType} \n{CarToAdd.EngineLitres} \n {CarToAdd.TypeOfCar} \n {CarToAdd.CarManufacturerId} \n {CarToAdd.Discount} \n {CarToAdd.Photo1} \n {CarToAdd.Price} \n {CarToAdd.Photo2} \n {CarToAdd.Photo3}");
            }
            else { MessageBox.Show("No such Car manufacturer!"); }
        }

        public bool registerAccount(string login, string email, string password, bool isAdmin)
        {
            var test = context.Accounts
                .Where(acc => acc.Login == login)
                .FirstOrDefault();

            var test1 = context.Accounts
                .Where(ac => ac.Login != null)
                .Select(ac => ac.Login)
                .FirstOrDefault()
                .ToString();
            List<string> logins = new List<string>();
            foreach (var item in test1)
            {
                logins.Add(item.ToString());
            }

            MessageBox.Show(logins.ToString());

            if (test == null)
            {
                Accounts AccToAdd = new Accounts();
                AccToAdd.Login = login;
                AccToAdd.Email = email;
                AccToAdd.Password = password;
                AccToAdd.IsAdmin = isAdmin;

                context.Accounts.Add(AccToAdd);
                context.SaveChanges();
                MessageBox.Show(logins.ToString());
                return true;
            }
            else {  MessageBox.Show(test.ToString()); return false; }
        }
    }

}
