using Autofac;
using PlanningPoker.Common.Constants;
using PlanningPoker.ViewModels;
using PlanningPoker.ViewModels.Base;

namespace PlanningPoker.Shared.AutofacModules
{
    public class ViewModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomeViewModel>().Named<ViewModelBase>(ViewNames.HomeView).InstancePerDependency();
        }
    }
}
