using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class Truck : MotorVehicle
    {
        public Truck()
        {
            this.MaxDistancePerRefuel = 200;
            this.MaxWeight = 1000;
            this.TopSpeed = 65;
        }
    }
}