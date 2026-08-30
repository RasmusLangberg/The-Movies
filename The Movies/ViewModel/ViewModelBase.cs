using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace The_Movies.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {   

        // Event som bruges af INotifyPropertyChanged.
        // WPF kan dermed få besked, når en property ændrer sig.
        public event PropertyChangedEventHandler? PropertyChanged;

        // Denne metode sender besked til WPF om,
        // at en bestemt property har ændret sig. uden PropertyChangedEventArgs ville WPF ikke opdatere det bruger ser på skærmen selvom værdien ædrede sig
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }


    }
}
