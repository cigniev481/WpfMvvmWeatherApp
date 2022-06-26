using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfMvvmWeatherApp.Messages;

namespace WpfMvvmWeatherApp.Services
{
    interface INavigationService
    {
        void NavigateTo<T>() where T : ViewModelBase;
    }

    class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage { ViewModelType = typeof(T) });
        }
    }
}
