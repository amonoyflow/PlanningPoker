using Autofac;
using PlanningPoker.Shared.AutofacModules;

namespace PlanningPoker.Shared
{
    public class AutofacBootstrapper
    {
        /// <summary>
        /// Gets or sets the instance of autofac modules.
        /// </summary>
        public static ILifetimeScope Instance { get; set; }

        /// <summary>
        /// Registers autofac modules.
        /// </summary>
        public static void RegisterAutofacModules()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new RepositoriesModule());
            containerBuilder.RegisterModule(new ViewModelsModule());
            containerBuilder.RegisterModule(new UtilitiesModule());
            containerBuilder.RegisterModule(new ManagersModule());
            containerBuilder.RegisterModule(new LocatorsModule());
            containerBuilder.RegisterModule(new ViewsModule());

            Instance = containerBuilder.Build();
        }
    }
}
