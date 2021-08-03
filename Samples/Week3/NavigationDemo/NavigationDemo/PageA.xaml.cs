using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace NavigationDemo
{
	public partial class PageA : ContentPage
	{
		public PageA()
		{
			InitializeComponent();
		}

		async void PageB_Clicked(System.Object sender, System.EventArgs e)
		{
			await this.Navigation.PushAsync(new PageB());
		}
	}
}
