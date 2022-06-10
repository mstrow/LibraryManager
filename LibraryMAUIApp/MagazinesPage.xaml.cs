using LibraryMAUIApp.ViewModel;
using RestAPIClient;

namespace LibraryMAUIApp;

public partial class MagazinesPage : ContentPage
{
    private readonly IMagazineClient _magazineClient;
    public MagazinesPage(BooksViewModel vm)
	{
        _magazineClient = new MagazineClient(App.Configuration, new System.Net.Http.HttpClient());
        InitializeComponent();
        BindingContext = vm;
        GetBooksAsync();
	}
    private async void GetBooksAsync()
    {
        var books = await _magazineClient.ListAsync();
        BooksCollectionView.ItemsSource = books.ToList();
    }

}