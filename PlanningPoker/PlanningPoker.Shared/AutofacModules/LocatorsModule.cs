using Autofac;
using PlanningPoker.BindingHandler;
using PlanningPoker.Common.Constants;

namespace PlanningPoker.Shared.AutofacModules
{
    public class LocatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewModelLocator>().As<IViewModelLocator>().Named<ViewModelLocator>(ViewNames.HomeView).WithParameter("viewName", ViewNames.HomeView).InstancePerDependency();
        }
    }
}
