using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class SecureStoragePage : ContentPage
	{
		public SecureStoragePage()
		{
			InitializeComponent();

			this.BindingContext = this;

		}

		private const string MY_KEY = "mykey";

        protected override async void OnAppearing()
        {
            base.OnAppearing();

			var value = await SecureStorage.GetAsync(MY_KEY);
			_SecureStorageText = value ?? string.Empty;
			OnPropertyChanged(nameof(SecureStorageText));

		}

		private string _SelectedImageLocation = string.Empty;
		public string SelectedImageLocation
		{
			get { return _SelectedImageLocation; }
			private set
            {
				if (_SelectedImageLocation != value)
                {
					_SelectedImageLocation = value;
					OnPropertyChanged(nameof(SelectedImageLocation));
                }
            }
		}

		private string _CapturedPictureLocation = string.Empty;
		public string CapturedPictureLocation
		{
			get { return _CapturedPictureLocation; }
			private set
			{
				if (_CapturedPictureLocation != value)
				{
					_CapturedPictureLocation = value;
					OnPropertyChanged(nameof(CapturedPictureLocation));
				}
			}
		}

		private string _SecureStorageText = string.Empty;
		public string SecureStorageText
		{
			get { return _SecureStorageText; }
			set
			{
				if (value != _SecureStorageText)
				{
					_SecureStorageText = value;
					SecureStorage.SetAsync(MY_KEY, value).ContinueWith((r) =>
					{
						OnPropertyChanged(nameof(SecureStorageText));
					});

				}
			}
		}
	}
}
