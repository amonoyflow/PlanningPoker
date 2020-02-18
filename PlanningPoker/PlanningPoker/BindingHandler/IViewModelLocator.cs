using System.ComponentModel;
using Xamarin.Forms;

namespace PlanningPoker.BindingHandler
{
    public interface IViewModelLocator
    {
        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        string ViewName { get; }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        Page View { get; }

        /// <summary>
        /// Gets the current view model.
        /// </summary>
        INotifyPropertyChanged ViewModel { get; }

        /// <summary>
        /// Initializes the view model and pass the parameter.
        /// </summary>
        /// <param name="parameter">The parameter passed.</param>
        void Initialize(object parameter);
    }
}
