using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace NavigationDemo
{
	public partial class PageB : ContentPage
	{
		public PageB()
		{
			InitializeComponent();

			Title = "Page B";
		}

		async void Modal_Nav(System.Object sender, System.EventArgs e)
		{
			await this.Navigation.PushModalAsync(new PageC(), true);
		}
	}
}
