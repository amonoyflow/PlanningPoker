using PlanningPoker.Navigation;
using System;

namespace PlanningPoker.ViewModels.Base
{
    public class ViewModelBase : NotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        /// <param name="navigator">The navigator.</param>
        public ViewModelBase(INavigator navigator)
        {
            this.Navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the application is busy on executing.
        /// </summary>
        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.Set(ref this._isBusy, value); }
        }

        /// <summary>
        /// Gets or sets the navigation of the application.
        /// </summary>
        public INavigator Navigator { get; set; }

        /// <summary>
        /// Initializes the instance of viewmodel.
        /// </summary>
        /// <param name="parameter">The parameter to pass on viewmodel.</param>
        public virtual void InitializeViewModel(object parameter = null)
        {
        }
    }
}
