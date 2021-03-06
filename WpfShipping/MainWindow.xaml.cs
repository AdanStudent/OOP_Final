﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfShipping.ViewModels;

namespace WpfShipping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ChangeViewControl_Loaded(object sender, RoutedEventArgs e) //ChangeViewControl_Loaded
        {
            DeliveryServiceVM viewControl = new DeliveryServiceVM();
            this.DataContext = viewControl;

            DeliveryShippingView.DataContext = viewControl;

        }
    }
}
