using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Maps.MapControl.WPF;
using WpfMvvmWeatherApp.Messages;
using WpfMvvmWeatherApp.ViewModels;

namespace WpfMvvmWeatherApp.Views
{
    public partial class DetailsView : UserControl
    {
        public DetailsView()
        {
            InitializeComponent();
        }
    }
}


