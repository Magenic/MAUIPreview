using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Microsoft.Maui;
using System.Threading.Tasks;

namespace ControlsDemo
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{
        private int REQUEST_GENERAL_PERMISSIONS = 55;
        private TaskCompletionSource messageCompleteTask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Microsoft.Maui.Essentials.Platform.Init(this, savedInstanceState);

            if (HasGeneralPermissions())
            {
                LoadApplication();
            }
 
        }

        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_GENERAL_PERMISSIONS)
            {
                if (MissingGeneralPermissions())
                {
                    await ShowMissingPermissions();
                }
                LoadApplication();
            }
        }

        private void LoadApplication()
        {

        }

        private bool HasGeneralPermissions()
        {
            bool returnValue = false;

            if (MissingGeneralPermissions())
            {
                ActivityCompat.RequestPermissions(this, new string[]
                    { Manifest.Permission.ReadContacts },
                    REQUEST_GENERAL_PERMISSIONS);
            }
            else
            {
                returnValue = true;
            }
            return returnValue;
        }

        private bool MissingGeneralPermissions()
        {
            return (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) != Permission.Granted);
        }

        private Task ShowMissingPermissions()
        {
            messageCompleteTask = new TaskCompletionSource();

            var builder = new AlertDialog.Builder(this);
            builder.SetTitle("Permission Issue");
            builder.SetMessage("Not all required permissions granted. The app may not run correctly");
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", NoPermissionClick);
            builder.Show();

            return messageCompleteTask.Task;
        }

        private void NoPermissionClick(object sendeer, DialogClickEventArgs e)
        {
            if (messageCompleteTask != null)
            {
                messageCompleteTask.SetResult();
                messageCompleteTask = null;
            }
        }
    }
}