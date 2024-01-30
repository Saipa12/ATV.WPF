using System.ComponentModel;
using System.Windows.Controls;

namespace ATV.WPF.Core
{
    public class BaseWindowViewModel<T> : BaseViewModel, INotifyPropertyChanged where T : ContentControl
    {
        protected T _Control = null;

        public BaseWindowViewModel(T control) => _Control = control;
    }
}