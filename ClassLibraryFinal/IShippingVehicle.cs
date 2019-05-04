using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public interface IShippingVehicle
    {
        uint TopSpeed { get; set; }
        uint MaxDistancePerRefuel { get; set; }
        uint MaxWeight { get; }
    }
}