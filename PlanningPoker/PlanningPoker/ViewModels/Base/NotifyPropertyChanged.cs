using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlanningPoker.ViewModels.Base
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the property that needs to be notified upon changes.
        /// </summary>
        /// <typeparam name="T">The property that needs to be notified.</typeparam>
        /// <param name="field">The field that needs to be notified.</param>
        /// <param name="newValue">The new value of th property.</param>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void Set<T>(ref T field, T newValue = default(T), [CallerMemberName]string propertyName = null)
        {
            if (field != null)
            {
                if (!field.Equals(newValue))
                {
                    field = newValue;
                    this.OnPropertyChanged(propertyName);
                }
            }
            else
            {
                if (newValue != null)
                {
                    field = newValue;
                    this.OnPropertyChanged(propertyName);
                }
            }
        }

        /// <summary>
        /// Called when property has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
