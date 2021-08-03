using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace NavigationDemo
{
	public partial class MyTabbedPage : TabbedPage
	{
		public MyTabbedPage()
		{
			InitializeComponent();

#if __ANDROID__
			Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
#endif
		}
	}
}
