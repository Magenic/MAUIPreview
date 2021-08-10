using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class MediaPage : ContentPage
	{
		public MediaPage()
		{
			InitializeComponent();

			this.BindingContext = this;

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

		private async void OnPickImageClicked(object sender, EventArgs e)
		{
			var result = await MediaPicker.PickPhotoAsync();
			if (result != null)
			{
				SelectedImageLocation = result.FullPath;
			}
		}

		private async void OnTakePictureClicked(object sender, EventArgs e)
		{
			var result = await MediaPicker.CapturePhotoAsync();
			if (result != null)
			{
				CapturedPictureLocation = result.FullPath;
			}
		}
	}
}
