﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelekomNevaSvyazWpfApp.Models
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?
                .Invoke(this,
                        new PropertyChangedEventArgs(propertyName));
        }
    }
}
