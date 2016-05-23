using Pacientes.Forms.Classes;
using Pacientes.Forms.Entities;
using Pacientes.Forms.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Pacientes.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //DataMap dataMap = DependencyService.Get<IDataMap>().GetData();

            var pin = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(19.394500, -99.174400),
                    Label = "World Trade Center",
                    Address = "World Trade Center Mexico City, Distrito Federal, México"
                },
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(19.394500, -99.174400), Distance.FromMiles(1.0)));
        }

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}