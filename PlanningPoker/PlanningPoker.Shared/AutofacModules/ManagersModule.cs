using Autofac;
using PlanningPoker.Managers;
using PlanningPoker.Managers.Interfaces;

namespace PlanningPoker.Shared.AutofacModules
{
    public class ManagersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsManager>().As<ISettingsManager>().InstancePerDependency();
        }
    }
}
