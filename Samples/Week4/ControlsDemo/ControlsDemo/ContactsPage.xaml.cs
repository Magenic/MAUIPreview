using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage()
		{
			InitializeComponent();

			this.BindingContext = this;

		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

			_DeviceContacts = await Microsoft.Maui.Essentials.Contacts.GetAllAsync();
			OnPropertyChanged(nameof(DeviceContacts));

		}


		public IEnumerable<Contact> _DeviceContacts = new List<Contact>();
		public IEnumerable<Contact> DeviceContacts
		{
            get { return _DeviceContacts; }
        }

		private Contact _SelectedContact = new Contact();
		public string SelectedContact
		{
			get { return _SelectedContact.DisplayName; }
		}

		private async void OnPickContactClicked(object sender, EventArgs e)
		{
			_SelectedContact = await Microsoft.Maui.Essentials.Contacts.PickContactAsync();
			OnPropertyChanged(nameof(SelectedContact));
		}
	}
}
