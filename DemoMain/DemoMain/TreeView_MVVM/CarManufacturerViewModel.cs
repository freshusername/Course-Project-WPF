//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DemoMain.EF;

//namespace DemoMain.TreeView_MVVM
//{
//    class CarManufacturerViewModel
//    {
//        readonly ReadOnlyCollection<CarModelViewModel> _models;
//        readonly CarManufacturerViewModel manufs;

//        public CarManufacturerViewModel(Cars[] cars)
//        {
//            _models = new ReadOnlyCollection<CarModelViewModel>(
//                (from car in cars
//                 select new CarModelViewModel(car))
//                .ToList());
//        }

//        public ReadOnlyCollection<CarModelViewModel> Models
//        {
//            get { return _models; }
//        }
//    }
//}