using System;

using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using Auth0.OidcClient;
using XamarinLooker.Model;
using Plugin.CurrentActivity;
namespace XamarinLooker.Droid
{
    [Activity( Label = "XamarinLooker", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = "com.wegolook.xamarinlooker",
        DataHost = AuthenticationConfig.Domain,
        DataPathPrefix = "/android/com.wegolook.xamarinlooker/callback")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            //CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            ActivityMediator.Instance.Send(intent.DataString);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}