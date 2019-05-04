using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class DefaultShippingService : IShippingService
    {

        public IShippingLocation ShippingLocation { get; protected set; }

        public uint ShippingDistance
        {
            get => throw new NotImplementedException();
        }

        protected uint getShippingDistance()
        {
            //terrible way to determine distance insn't real
            return (uint)Math.Abs(this.ShippingLocation.DestinationZipCode - this.ShippingLocation.StartZipCode);
        }
        public uint NumRefuels
        {
            get => throw new NotImplementedException();
        }

        private uint getNumRefuels()
        {
            return (uint)this.ShippingDistance / (uint)this.DeliveryService.ShippingVehicle.MaxDistancePerRefuel;
        }

        public IDeliveryService DeliveryService { get; set; }

        List<IProduct> Products { get; set; }

        public DefaultShippingService(IDeliveryService Service,  List<IProduct> Products, IShippingLocation Location)
        {
            
        }

        public double ShippingCost()
        {
            return 0;
        }

        

        
    }
}