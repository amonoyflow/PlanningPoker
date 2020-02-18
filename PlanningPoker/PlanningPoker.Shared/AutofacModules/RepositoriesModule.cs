using Autofac;
using PlanningPoker.Repositories;
using PlanningPoker.Repositories.Interfaces;

namespace PlanningPoker.Shared.AutofacModules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Database>().As<IDatabase>().InstancePerDependency();
            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>().InstancePerDependency();
        }
    }
}
