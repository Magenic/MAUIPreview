using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Handlers
{
    public static class CombinedLabels
    {
        public static void SetupHandler()
        {
#if __ANDROID__
            Microsoft.Maui.Handlers.LabelHandler.LabelMapper[nameof(Microsoft.Maui.Controls.VisualElement.BackgroundColor)] = (h, v) =>
            {
                if (v is CustomLabel)
                {
                    (h.NativeView as Android.Views.View).SetBackgroundColor(Android.Graphics.Color.PowderBlue);
                }
                else
                {
                    (h.NativeView as Android.Views.View).SetBackgroundColor(Android.Graphics.Color.ForestGreen);
                }
            };
#endif
        }
    }
}
