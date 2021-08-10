using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class BatteryPage : ContentPage
	{
		public BatteryPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
		}

        private void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
			OnPropertyChanged(nameof(EnergySaver));
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
			OnPropertyChanged(nameof(ChargeLevel));
			OnPropertyChanged(nameof(State));
			OnPropertyChanged(nameof(PowerSource));
        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
			Battery.EnergySaverStatusChanged -= Battery_EnergySaverStatusChanged;
		}

		public string ChargeLevel
        {
            get { return $"Battery Level: {Battery.ChargeLevel.ToString()}"; }
        }

		public string EnergySaver
		{
			get { return $"Energy Saver: {Battery.EnergySaverStatus.ToString()}"; }
		}

		public string PowerSource
		{
			get { return $"Power Source: {Battery.PowerSource.ToString()}"; }
		}

		public string State
		{
			get { return $"State: {Battery.State.ToString()}"; }
		}
	}
}
