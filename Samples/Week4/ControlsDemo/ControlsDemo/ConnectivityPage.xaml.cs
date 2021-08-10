using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class ConnectivityPage : ContentPage
	{
		public ConnectivityPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
		}

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
			OnPropertyChanged(nameof(NetworkStatus));
			OnPropertyChanged(nameof(Connections));
		}

		protected override void OnDisappearing()
        {
            base.OnDisappearing();

			Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;

		}

		public string NetworkStatus
        {
			get
            {
				return Connectivity.NetworkAccess.ToString();
			}
        }

		public IEnumerable<ConnectionProfile> Connections
		{
            get { return Connectivity.ConnectionProfiles.ToList(); }
        }
	}
}
