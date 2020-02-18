using Autofac;
using PlanningPoker.Common.Constants;
using PlanningPoker.Views;
using Xamarin.Forms;

namespace PlanningPoker.Shared.AutofacModules
{
    public class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeView>().Named<MasterDetailPage>(ViewNames.HomeView).InstancePerDependency();
        }
    }
}
