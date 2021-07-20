using System;
using FirstProject.Handlers;
using Microsoft.Maui.Controls;

namespace FirstProject
{
	public partial class CustomControlPage : ContentPage
	{
		public CustomControlPage()
		{
			//AllLabels.SetupHandler();
			//CustomLabels.SetupHandler();
			CombinedLabels.SetupHandler();
			
			InitializeComponent();

		}
	}
}
