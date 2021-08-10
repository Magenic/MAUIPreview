using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class AccelerometerPage : ContentPage
	{
		public AccelerometerPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
			X = e.Reading.Acceleration.X.ToString();
			Y = e.Reading.Acceleration.Y.ToString();
			Z = e.Reading.Acceleration.Z.ToString();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (HasAccelerometer())
			{
				Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
				Accelerometer.Start(SensorSpeed.Default);
			}
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

			if (HasAccelerometer())
			{
				Accelerometer.Stop();
				Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
			}
		}

        public bool HasAccelerometer()
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
			returnValue = Windows.Devices.Sensors.Accelerometer.GetDefault() != null;
#endif
			return returnValue;
		}

		public string AccelerometerDetected
        {
			get
            {
				return HasAccelerometer() ? "Accelerometer Detected" : "Accelerometer Not Detected";
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

		private string _Y = string.Empty;
		public string Y
		{
			get { return _Y; }
			set
			{
				if (value != _Y)
				{
					_Y = value;
					OnPropertyChanged(nameof(Y));
				}
			}
		}

		private string _Z = string.Empty;
		public string Z
		{
			get { return _Z; }
			set
			{
				if (value != _Z)
				{
					_Z = value;
					OnPropertyChanged(nameof(Z));
				}
			}
		}

	}
}
