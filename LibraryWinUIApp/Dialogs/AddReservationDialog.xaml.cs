using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RestAPIClient;
using Models;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LibraryWinUIApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class AddReservationDialog : ContentDialog
    {
        private readonly ILibraryClient _libraryClient;
        private readonly ICustomerClient _customerClient;
        private readonly IPictureBookClient _pictureBookClient;
        private readonly INovelClient _novelClient;
        private readonly IMagazineClient _magazineClient;
        private readonly IReservationClient _reservationClient;

        public DialogResult Result { get; private set; }

        private List<CustomerModel> Customers = new List<CustomerModel>();

        private List<LibraryModel> Libraries = new List<LibraryModel>();

        private IList<IBookModel> Books = new List<IBookModel>();

        public AddReservationDialog()
        {
            
            _libraryClient = new LibraryClient(App.Configuration, new System.Net.Http.HttpClient());
            _customerClient = new CustomerClient(App.Configuration, new System.Net.Http.HttpClient());
            _pictureBookClient = new PictureBookClient(App.Configuration, new System.Net.Http.HttpClient());
            _novelClient = new NovelClient(App.Configuration, new System.Net.Http.HttpClient());
            _magazineClient = new MagazineClient(App.Configuration, new System.Net.Http.HttpClient());
            _reservationClient = new ReservationClient(App.Configuration, new System.Net.Http.HttpClient());

            this.InitializeComponent();

            UpdateCustomers();
            UpdateLibraries();
            UpdateBooks();

            DueDateDatePicker.Date = DateTime.Now;
        }

        public async void UpdateCustomers()
        {
            var customers = await _customerClient.ListAsync();
            Customers = customers.ToList();
            CustomersComboBox.ItemsSource = Customers;
        }
        public async void UpdateLibraries()
        {
            var libraries = await _libraryClient.ListAsync();
            Libraries = libraries.ToList();
            LibraryComboBox.ItemsSource = Libraries;
        }
        public async void UpdateBooks()
        {
            if (BookTypeComboBox.SelectedIndex == 0)
            {
                var books = await _novelClient.ListAsync();
                BookComboBox.ItemsSource = books.ToList();
                BookComboBox.SelectedIndex = 0;
            }
            else if (BookTypeComboBox.SelectedIndex == 1)
            {
                var books = await _magazineClient.ListAsync();
                BookComboBox.ItemsSource = books.ToList();
                BookComboBox.SelectedIndex = 0;
            }
            else if (BookTypeComboBox.SelectedIndex == 2)
            {
                var books = await _pictureBookClient.ListAsync();
                BookComboBox.ItemsSource = books.ToList();
                BookComboBox.SelectedIndex = 0;
            }
        }

        private void BookTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooks();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            if (await AddReservation())
            {
                this.Result = DialogResult.OK;
            }
            else
            {
                this.Result = DialogResult.Fail;
            }
            deferral.Complete();
        }
        private async Task<bool> AddReservation()
        {
            ReservationModel res = new ReservationModel();
            var selectedLibrary = LibraryComboBox.SelectedItem as LibraryModel;
            var selectedCustomer = CustomersComboBox.SelectedItem as CustomerModel;
            var selectedBook = BookComboBox.SelectedItem as IBookModel;
            var selectedDate = DueDateDatePicker.SelectedDate.GetValueOrDefault();
            res.LibraryID = selectedLibrary.ID;
            res.Library = selectedLibrary;
            res.CustomerID = selectedCustomer.ID;
            res.Customer = selectedCustomer;
            res.BookID = selectedBook.ID;
            res.Book = selectedBook;
            res.Date = selectedDate.DateTime;
            await _reservationClient.AddAsync(res);
            return true;
        }
    }
}
