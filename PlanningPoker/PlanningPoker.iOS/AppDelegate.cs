using Autofac;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PlanningPoker.Shared;
using UIKit;
using Xamarin.Forms;

namespace PlanningPoker.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            AppCenter.Start("c311d926-f50d-4b0b-b60f-4b54c72ed070", typeof(Analytics), typeof(Crashes));

            this.RegisterAutofacModules(out App application);
            this.LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        private void RegisterAutofacModules(out App application)
        {
            AutofacBootstrapper.RegisterAutofacModules();

            application = AutofacBootstrapper.Instance.Resolve<App>();
        }
    }
}
