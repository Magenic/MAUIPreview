using System;
using Microsoft.Maui.Controls;

namespace NavigationDemo
{
	public partial class PageC : ContentPage
	{
		public PageC()
		{
			InitializeComponent();

			Title = "Page C";
		}

		async void Modal_Complete(System.Object sender, System.EventArgs e)
		{
			await this.Navigation.PopModalAsync(true);
		}
	}
}
