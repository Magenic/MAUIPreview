using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class BarometerPage : ContentPage
	{
		public BarometerPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (HasBarometer())
			{
				Barometer.ReadingChanged += Barometer_ReadingChanged;
				Barometer.Start(SensorSpeed.Default);
			}
		}

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
			X = e.Reading.PressureInHectopascals.ToString();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

			if (HasBarometer())
			{
				Barometer.Stop();
				Barometer.ReadingChanged -= Barometer_ReadingChanged;
			}
		}

        public bool HasBarometer()
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
			returnValue = false;
#endif
			return returnValue;
		}

		public string DeviceDetected
        {
			get
            {
				return HasBarometer() ? "Barometer Detected" : "Barometer Not Detected";
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
