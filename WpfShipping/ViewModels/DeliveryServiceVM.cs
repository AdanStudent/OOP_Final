using ClassLibraryFinal;
using System.ComponentModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using ClassLibraryFinal.ShippingService;

namespace WpfShipping.ViewModels
{
    public class DeliveryServiceVM : INotifyPropertyChanged
    {

        public ICommand updateService { get; set; }

        public IShippingService shippingService;

        public ObservableCollection<IDeliveryService> DeliveryServices { get; set; }

        public IDeliveryService SelectedService { get; set; }
        public uint startZip { get; private set; }
        public uint StartZip
        {
            get { return startZip; }
            set
            {
                if (this.startZip != value)
                {
                    startZip = value;
                    RaisePropertyChanged("StartZip");
                }
            }
        }

        public uint endZip { get; private set; }
        public uint EndZip
        {
            get { return endZip; }
            set
            {
                if (this.endZip != value)
                {
                    endZip = value;
                    RaisePropertyChanged("EndZip");
                }
            }
        }

        public string ShipDistance
        {
            get { return $"{this.shippingService.ShippingDistance}"; }
        }

        public string Refuels
        {
            get { return $"{this.shippingService.NumRefuels}"; }
        }

        public DeliveryServiceVM()
        {
            this.updateService = new UpdateServiceCommand(ExecuteCommandUpdateDelievryService, CanExecuteCommand);
            NewDefaultShippingService();

            this.DeliveryServices = new ObservableCollection<IDeliveryService>()
            {
                new SnailService(new ShippingSnail()),
                new UnclesTruck(new Truck()),
                new AirExpress(new Plane())
            };

            this.SelectedService = this.DeliveryServices[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        private bool CanExecuteCommand(object parameter)
        {
            return true;
        }

        private void ExecuteCommandUpdateDelievryService(object parameter)
        {
            NewDefaultShippingService();
            RaisePropertyChanged("Refuels");
            RaisePropertyChanged("ShipDistance");
        }



        private void NewDefaultShippingService()
        {
            shippingService = new DefaultShippingService(this.SelectedService, new List<IProduct>(),
                            new ShippingLocation() { StartZipCode = startZip, DestinationZipCode = endZip });
        }
    }
}
