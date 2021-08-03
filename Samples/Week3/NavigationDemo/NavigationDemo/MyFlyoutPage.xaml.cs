using System;
using Microsoft.Maui.Controls;

namespace NavigationDemo
{
	public partial class MyFlyoutPage : FlyoutPage
	{
		public MyFlyoutPage()
		{
			InitializeComponent();

			Title = "Flyout Page";

            this.FlyoutLayoutBehavior = FlyoutLayoutBehavior.SplitOnLandscape; 

            flyoutPage.listView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                flyoutPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
