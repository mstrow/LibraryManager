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
    class SelectedBook : INotifyPropertyChanged
    {
        private IBookModel bookModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public IBookModel Book
        {
            get => bookModel;
            set
            {
                NotifyPropertyChanged();
                bookModel = value;
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
