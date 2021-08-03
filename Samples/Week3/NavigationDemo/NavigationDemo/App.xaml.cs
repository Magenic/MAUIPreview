using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Graphics;
using Application = Microsoft.Maui.Controls.Application;

namespace NavigationDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var navPage = new NavigationPage(new PageA());
			navPage.BarTextColor = Colors.White;
			navPage.BarBackgroundColor = Color.FromArgb("#512BD4");

			MainPage = navPage;
		}
	}
}
