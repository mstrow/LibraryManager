using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Models;
using RestAPIClient;

namespace LibraryMAUIApp.ViewModel
{
    [QueryProperty(nameof(Id), nameof(Id))]
    [QueryProperty(nameof(Isbn), nameof(Isbn))]
    [QueryProperty(nameof(Year), nameof(Year))]
    [QueryProperty(nameof(Title), nameof(Title))]
    [QueryProperty(nameof(Author), nameof(Author))]
    [QueryProperty(nameof(Description), nameof(Description))]
    [QueryProperty(nameof(Imageurl), nameof(Imageurl))]
    public partial class BookViewModel : ObservableObject
    {
        [ObservableProperty]
        int id;

        [ObservableProperty]
        string isbn;

        [ObservableProperty]
        int year;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string author;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        string imageurl;

        private readonly IReservationClient _reservationClient;

        public BookViewModel()
        {
            _reservationClient = new ReservationClient(App.Configuration, new System.Net.Http.HttpClient());
        }

        [ICommand]
        async Task Reserve()
        {
            ReservationModel reservation = new ReservationModel();
            reservation.LibraryID = 1;
            reservation.CustomerID = 2;
            reservation.BookID = id;
            reservation.Date = DateTime.Now;
            await _reservationClient.AddAsync(reservation);

            await Shell.Current.GoToAsync("..");
        }
    }
}
