using Autofac;
using PlanningPoker.Navigation;
using PlanningPoker.Repositories.Interfaces;

#if __ANDROID__
using PlanningPoker.Droid.Database;
#elif __IOS__
using PlanningPoker.iOS.Database;
#endif

namespace PlanningPoker.Shared.AutofacModules
{
    public class UtilitiesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>().AsSelf();
            builder.RegisterType<Navigator>().As<INavigator>().InstancePerDependency();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerDependency();
        }
    }
}
