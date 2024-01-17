using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.Utilities
{
    //implementiert INotifyPropertyChanged-Interface um Änderungen an Eigenschaften der ViewModel-Klasse zu melden
    public class ViewModelBase: INotifyPropertyChanged
    {
        //Ereignis wird aus INotifyPropertyChanged-Interface implementiert
        public event PropertyChangedEventHandler PropertyChanged;

        //signalisiert Änderung an einer Eigenschaft
        //CallMemberName --> automatische Verwendung des Namens der eigentlichen Eigenschaft
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
