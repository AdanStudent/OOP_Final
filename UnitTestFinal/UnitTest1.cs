using System;
using ClassLibraryFinal;
using ClassLibraryFinal.NinjectModules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace UnitTestFinal
{
    [TestClass]
    public class UnitTest1
    {
        IKernel kernel;

        public UnitTest1()
        {
            this.kernel = new StandardKernel(new ShippingServiceModule());
        }

        [TestMethod]
        public void TestMockRadioFlyer()
        {
            uint mockMaxDist = 1;
            uint mockMaxWeight = 30;

            Mock<IShippingVehicle> mockShippingVehicle = new Mock<IShippingVehicle>();

            mockShippingVehicle.SetupGet(v => v.MaxDistancePerRefuel).Returns(1);
            mockShippingVehicle.SetupGet(v => v.MaxWeight).Returns(30);

            Assert.AreEqual(mockMaxDist, mockShippingVehicle.Object.MaxDistancePerRefuel);
            Assert.AreEqual(mockMaxWeight, mockShippingVehicle.Object.MaxWeight);
        }

        [TestMethod]
        public void TestMockDelivery()
        {
            uint mockRefulCost = 2;

            Mock<IShippingVehicle> mockShippingWagon = new Mock<IShippingVehicle>();
            mockShippingWagon.SetupGet(v => v.MaxDistancePerRefuel).Returns(50);
            mockShippingWagon.SetupGet(v => v.MaxWeight).Returns(100);

            Mock<IDeliveryService> mockDelivery = new Mock<IDeliveryService>();
            mockDelivery.SetupGet(d => d.CostPerRefuel).Returns(2);
            mockDelivery.SetupGet(d => d.ShippingVehicle).Returns(mockShippingWagon.Object);


            Assert.AreEqual(mockRefulCost, mockDelivery.Object.CostPerRefuel);
            Assert.AreEqual(mockShippingWagon.Object, mockDelivery.Object.ShippingVehicle);
        }

        [TestMethod]
        public void TestMockDelivery_Shipping()
        {
            uint maxDist = 1;
            uint maxWeight = 30;
            uint refuelCost = 2;

            uint destZip = 60605;
            uint startZip = 60613;

            Mock<IShippingLocation> mockLocation = new Mock<IShippingLocation>();
            mockLocation.SetupGet(l => l.DestinationZipCode).Returns(60605);
            mockLocation.SetupGet(l => l.StartZipCode).Returns(60613);

            Mock<IShippingVehicle> mockShippingWagon = new Mock<IShippingVehicle>();
            mockShippingWagon.SetupGet(v => v.MaxDistancePerRefuel).Returns(50);
            mockShippingWagon.SetupGet(v => v.MaxWeight).Returns(100);

            Mock<IDeliveryService> mockDelivery = new Mock<IDeliveryService>();
            mockDelivery.SetupGet(d => d.CostPerRefuel).Returns(2);
            mockDelivery.SetupGet(d => d.ShippingVehicle).Returns(mockShippingWagon.Object);

            Mock<IShippingService> mockShipping = new Mock<IShippingService>();
            mockShipping.SetupGet(s => s.DeliveryService).Returns(mockDelivery.Object);
            mockShipping.SetupGet(s => s.ShippingLocation).Returns(mockLocation.Object);

            uint dist = (uint)Math.Abs(destZip - startZip);
            mockShipping.SetupGet(s => s.ShippingDistance).Returns(dist);

            uint refuels = dist / maxDist;
            mockShipping.SetupGet(s => s.NumRefuels).Returns(refuels);

            Assert.AreEqual(mockLocation.Object, mockShipping.Object.ShippingLocation);
            Assert.AreEqual(mockDelivery.Object, mockShipping.Object.DeliveryService);
            Assert.AreEqual(dist, mockShipping.Object.ShippingDistance);    
            Assert.AreEqual(refuels, mockShipping.Object.NumRefuels);

        }


    }
}
