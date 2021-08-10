using System;
using Microsoft.Maui.Controls;

namespace ControlsDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void OnAccelerometerClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AccelerometerPage());
		}

		private async void OnBarometerClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BarometerPage());
		}

		private async void OnBatteryClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BatteryPage());
		}

		private async void OnClipboardClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ClipboardPage());
		}

		private async void OnCompassClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CompassPage());
		}

		private async void OnConnectivityClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ConnectivityPage());
		}


		private async void OnContactsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ContactsPage());
		}

		private async void OnMediaClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MediaPage());
		}

		private async void OnSecureStorageClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SecureStoragePage());
		}
	}
}