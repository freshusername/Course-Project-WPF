//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DemoMain.EF;

//namespace DemoMain.TreeView_MVVM
//{
//    class CarModelViewModel : TreeViewItemViewModel
//    {
//        readonly Cars _car;

//        public CarModelViewModel(Cars car, CarManufacturerViewModel parentState)
//            : base(parentState, false)
//        {
//            _car = car;
//        }

//        public string CityName
//        {
//            get { return _car.Model; }
//        }
//    }
//}