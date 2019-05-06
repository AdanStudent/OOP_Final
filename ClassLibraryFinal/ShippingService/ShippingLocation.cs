using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFinal.ShippingService
{
    public class ShippingLocation : IShippingLocation
    {
        public uint StartZipCode { get; set; }

        public uint DestinationZipCode { get; set; }
    }
}
