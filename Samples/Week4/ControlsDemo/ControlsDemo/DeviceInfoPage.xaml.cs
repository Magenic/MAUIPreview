using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class DeviceInfoPage : ContentPage
	{
		public DeviceInfoPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

		public string DeviceType
		{
			get
            {
				return DeviceInfo.DeviceType.ToString();
			}
        }

		public string Idiom
		{
			get
			{
				return DeviceInfo.Idiom.ToString();
			}
		}

		public string Manufacturer
		{
			get
			{
				return DeviceInfo.Manufacturer;
			}
		}

		public string Model
		{
			get
			{
				return DeviceInfo.Model;
			}
		}

		public string Name
		{
			get
			{
				return DeviceInfo.Name;
			}
		}

		public string Platform
		{
			get
			{
				return DeviceInfo.Platform.ToString();
			}
		}

		public string Version
		{
			get
			{
				return DeviceInfo.Version.ToString();
			}
		}

		public string VersionString
		{
			get
			{
				return DeviceInfo.VersionString;
			}
		}
		}
}
