using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoMain.Model;


namespace DemoMain.GetCar_BuilderPattern
{
    interface IVehicleBuilder
    {
        void getVehicleInfo(string model);
        Cars GetVehicle();
    }
}
