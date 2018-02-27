using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextBlockFormating
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, eventArgs);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Helper Method to raise INotifyProperty change.
        /// </summary>
        protected void RaiseAndSetIfChanged(ref string field, string value, [CallerMemberName] string propertyName = null)
        {

            if (field == value) return;

            if (field == null && string.IsNullOrEmpty(value)) return;
            if (string.IsNullOrEmpty(field) && value == null ) return;

            field = value;

            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Helper Method to raise INotifyProperty change.
        /// </summary>
        protected void RaiseAndSetIfChanged(ref bool field, bool value, [CallerMemberName] string propertyName = null)
        {
            if (field == value) return;
            field = value;

            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

    }
}