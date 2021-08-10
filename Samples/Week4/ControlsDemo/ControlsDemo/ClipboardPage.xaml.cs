using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace ControlsDemo
{
	public partial class ClipboardPage : ContentPage
	{
		public ClipboardPage()
		{
			InitializeComponent();

			this.BindingContext = this;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			_ClipboardText = Clipboard.HasText? await Clipboard.GetTextAsync(): string.Empty;
			OnPropertyChanged(nameof(ClipboardText));

			Clipboard.ClipboardContentChanged += Clipboard_ClipboardContentChanged;
		}

        private async void Clipboard_ClipboardContentChanged(object sender, EventArgs e)
        {
			ClipboardText = Clipboard.HasText ? await Clipboard.GetTextAsync() : string.Empty;
		}


		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			Clipboard.ClipboardContentChanged -= Clipboard_ClipboardContentChanged;
		}

		private string _ClipboardText = string.Empty;
		public string ClipboardText
		{
			get { return _ClipboardText; }
			set
			{
				if (value != _ClipboardText)
				{
					_ClipboardText = value;
					Clipboard.SetTextAsync(value).ContinueWith((r) =>
					{
						OnPropertyChanged(nameof(ClipboardText));
					});

				}
			}
		}
	}
}
