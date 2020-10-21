using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tenta.Services;
using Xamarin.Forms;

namespace Tenta.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IApiService service;
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            service = DependencyService.Get<IApiService>();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
                       [CallerMemberName] string propertyName = "",
                       Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
