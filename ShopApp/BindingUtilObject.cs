using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using ShopApp.ViewModels;
using ShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShopApp
{
    public class BindingUtilObject : ObservableObject
    {
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void HelpSupportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClienteSeleccionado))
            {
                var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
                await Shell.Current.GoToAsync(uri);
            }
        }

        private object ClienteSeleccionado()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
