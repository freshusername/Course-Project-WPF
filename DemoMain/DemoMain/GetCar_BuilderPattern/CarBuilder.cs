using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoMain.DbGetData_Singleton;
using DemoMain.Model;


namespace DemoMain.GetCar_BuilderPattern
{
    public class CarBuilder : IVehicleBuilder
    {
        SingletonDb sig = SingletonDb.getInstance();

        private Cars _car = new Cars();
       
        public void getVehicleInfo(string model)
        {
            sig.getVehicleInfo(model);
        }
        

        public Cars GetVehicle()
        {
            return sig.getVehicle();
        }
    }
}

