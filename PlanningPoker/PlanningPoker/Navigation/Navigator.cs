using Autofac;
using PlanningPoker.BindingHandler;
using PlanningPoker.Common.Constants;
using System;
using System.Threading.Tasks;

namespace PlanningPoker.Navigation
{
    public class Navigator : INavigator
    {
        private readonly ILifetimeScope lifetimeScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="Navigator"/> class.
        /// </summary>
        /// <param name="lifetimeScope">The lifetime scope.</param>
        /// <exception cref="ArgumentNullException">lifetimeScope</exception>
        public Navigator(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        /// <summary>
        /// Gets the navigation base.
        /// </summary>
        public NavigatorBase NavigationBase { get; set; }

        /// <summary>
        /// Push the page to another page based on the name of the view.
        /// </summary>
        /// <param name="viewName">The name of the view.</param>
        /// <param name="parameter">The parameter to pass to next view.</param>
        /// <returns>The task after navigating to another page.</returns>
        public async Task PushToView(string viewName, object parameter = null)
        {
            var viewModel = this.lifetimeScope.ResolveNamed<ViewModelLocator>(viewName);

            if (viewModel != null)
            {
                viewModel.Initialize(parameter);

                await this.NavigationBase.PushAsync(viewModel.View);
            }
        }

        /// <summary>
        /// Pops to previous page based on the last page inserted in stack.
        /// </summary>
        /// <param name="parameter">The parameter to pass to previous view.</param>
        /// <returns>The task after navigating back to previous view.</returns>
        public async Task PopToPreviousView(object parameter = null)
        {
            var viewModel = this.lifetimeScope.ResolveNamed<ViewModelLocator>(ViewNames.HomeView);

            if (viewModel != null)
            {
                viewModel.Initialize(parameter);

                await this.NavigationBase.PopAsync();
            }
        }

        /// <summary>
        /// Pops to root page.
        /// </summary>
        /// <returns>The task after navigating back to root view.</returns>
        public async Task PopToRootView()
        {
            await this.NavigationBase.PopToRootAsync();
        }

        /// <summary>
        /// Initializes the root view.
        /// </summary>
        /// <param name="rootViewName">Name of the root view.</param>
        public void InitializeRootView(string rootViewName)
        {
            var viewModel = this.lifetimeScope.ResolveNamed<ViewModelLocator>(rootViewName);

            if (viewModel != null)
            {
                viewModel.Initialize(null);

                this.NavigationBase = new NavigatorBase(viewModel.View);
            }
        }
    }
}
