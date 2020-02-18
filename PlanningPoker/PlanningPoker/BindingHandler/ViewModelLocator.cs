using Autofac;
using PlanningPoker.ViewModels.Base;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace PlanningPoker.BindingHandler
{
    public class ViewModelLocator : IViewModelLocator
    {
        public ViewModelLocator(ILifetimeScope lifetimeScope, string viewName)
        {
            this.LifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
            this.ViewName = viewName;
        }

        /// <summary>
        /// Gets the scope manager.
        /// </summary>
        protected ILifetimeScope LifetimeScope { get; }

        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        public string ViewName { get; }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        private Page view;
        public Page View { get => this.view; }

        /// <summary>
        /// Gets the current view model.
        /// </summary>
        private ViewModelBase viewModel;
        public INotifyPropertyChanged ViewModel { get => this.viewModel; }

        /// <summary>
        /// Initializes the view model and pass the parameter.
        /// </summary>
        /// <param name="parameter">The parameter passed.</param>
        public virtual void Initialize(object parameter)
        {
            this.view = this.LifetimeScope.ResolveNamed<MasterDetailPage>(this.ViewName);

            NavigationPage.SetHasNavigationBar(this.view, false);

            this.viewModel = this.LifetimeScope.ResolveNamed<ViewModelBase>(this.ViewName);

            this.view.BindingContext = this.viewModel;

            this.viewModel.InitializeViewModel(parameter);
        }
    }
}
