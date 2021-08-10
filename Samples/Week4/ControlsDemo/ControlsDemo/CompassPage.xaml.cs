using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class CompassPage : ContentPage
	{
		public CompassPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (HasCompass())
			{
				Compass.ReadingChanged += Compass_ReadingChanged;
				Compass.Start(SensorSpeed.Default);
			}
		}

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
			X = e.Reading.HeadingMagneticNorth.ToString();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

			if (HasCompass())
			{
				Compass.Stop();
				Compass.ReadingChanged -= Compass_ReadingChanged;
			}
		}

        public bool HasCompass()
		{
			bool returnValue = false;
#if __ANDROID__
			// android emulates the accelerometer
			returnValue = true;
#elif __IOS__
			// all iOS devices (and only devices) have an accelerometer
			returnValue = Microsoft.Maui.Essentials.DeviceInfo.DeviceType == Microsoft.Maui.Essentials.DeviceType.Physical;
#elif WINDOWS_UWP || WINDOWS
			// UWP does not emulate, and only some devices have, an accelerometer
			returnValue = Windows.Devices.Sensors.Compass.GetDefault() != null;;
#endif
			return returnValue;
		}

		public string DeviceDetected
        {
			get
            {
				return HasCompass() ? "Compass Detected" : "Compass Not Detected";
			}
        }

		private string _X = string.Empty;
		public string X
        {
            get { return _X; }
			set
            {
				if (value != _X)
                {
					_X = value;
					OnPropertyChanged(nameof(X));
                }
            }
        }
	}
}
