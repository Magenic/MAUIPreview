using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Handlers
{
    public static class AllLabels
    {
        public static void SetupHandler()
        {
#if __ANDROID__
            Microsoft.Maui.Handlers.LabelHandler.LabelMapper.Add("fjksdfksdlfks", (h, v) =>
            {
                (h.NativeView as Android.Views.View).SetBackgroundColor(Android.Graphics.Color.ForestGreen);
            });
#endif
        }
    }
}
