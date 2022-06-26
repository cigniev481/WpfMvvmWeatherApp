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
using WpfMvvmWeatherApp.Messages;
using WpfMvvmWeatherApp.ViewModels;

namespace WpfMvvmWeatherApp.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        public AddView()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var location = Map.ViewportPointToLocation(e.GetPosition(Map));

            //var messenger = App.Services.GetInstance<IMessenger>();
            //messenger.Send(new LocationMessage { Latitude = location.Latitude, Longitude = location.Longitude });

            if (DataContext is AddViewModel viewModel)
            {
                viewModel.Latitude = location.Latitude.ToString();
                viewModel.Longitude = location.Longitude.ToString();
            }
        }
    }
}
