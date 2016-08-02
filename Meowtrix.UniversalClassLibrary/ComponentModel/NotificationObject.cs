using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Meowtrix.ComponentModel
{
    /// <summary>
    /// Provide a base class for <see cref="INotifyPropertyChanged"/> and can be used for data binding.
    /// </summary>
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">Name of the changed property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string name = null)
        {
            var temp = PropertyChanged;
            temp?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Raise the <see cref="PropertyChanged"/> event declaring all of the properties have been changed.
        /// </summary>
        protected virtual void OnAllPropertyChanged() => OnPropertyChanged(null);
    }
}
