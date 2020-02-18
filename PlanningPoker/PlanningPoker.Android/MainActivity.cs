using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Autofac;
using Lottie.Forms.Droid;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PlanningPoker.Shared;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlanningPoker.Droid
{
    [Activity(
        Label = "Planning Poker", 
        Icon = "@mipmap/ic_planningpoker", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            AnimationViewRenderer.Init();
            AutofacBootstrapper.RegisterAutofacModules();

            this.LoadApplication(AutofacBootstrapper.Instance.Resolve<App>());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();

            AppCenter.Start("android=091dbe0c-b4ec-413d-ab2f-2919965d4151;", typeof(Analytics), typeof(Crashes));
        }
    }
}