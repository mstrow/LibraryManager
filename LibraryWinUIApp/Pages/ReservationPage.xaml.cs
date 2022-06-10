using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Models;
using RestAPIClient;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LibraryWinUIApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class ReservationPage : Page
    {
        private readonly IReservationClient _reservationClient;

        private SelectedReservation SelectedReservation;


        public ReservationPage()
        {
            _reservationClient = new ReservationClient(App.Configuration, new System.Net.Http.HttpClient());
            this.InitializeComponent();
            this.SelectedReservation = new SelectedReservation();
            GetReservationsAsync();
        }

        private async void GetReservationsAsync()
        {
            LoadingProgressRing.IsActive = true;
            var reservations = await _reservationClient.ListAsync();
            ReservationListView.ItemsSource = reservations.ToList();
            TotalTextBlock.Text = "Total: " + reservations.Count.ToString();
            if(reservations.Count >= 1)
            {
                ReservationListView.SelectedIndex = 0;
                SelectedReservation.Reservation = ReservationListView.SelectedItem as ReservationModel;
                DeleteButton.IsEnabled = true;
            }
            LoadingProgressRing.IsActive = false;

        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            GetReservationsAsync();
        }
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Are you sure you want to delete Reservation ID: " + SelectedReservation.Reservation.ID.ToString() + "?";
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Yes";
            dialog.CloseButtonText = "No";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                _reservationClient.DeleteAsync(SelectedReservation.Reservation.ID);
                GetReservationsAsync();
            }
        }

        private async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddReservationDialog dialog = new AddReservationDialog();
            dialog.XamlRoot = this.XamlRoot;
            await dialog.ShowAsync();
            GetReservationsAsync();
        }

        private void ReservationListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedReservation.Reservation = ReservationListView.SelectedItem as ReservationModel;
        }
    }
}
