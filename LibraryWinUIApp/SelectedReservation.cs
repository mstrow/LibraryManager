using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LibraryWinUIApp
{
    class SelectedReservation : INotifyPropertyChanged
    {
        private ReservationModel reservationModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public ReservationModel Reservation { get => reservationModel;
            set {
                NotifyPropertyChanged();
                reservationModel = value; 
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
