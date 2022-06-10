using LibraryMAUIApp.ViewModel;
using RestAPIClient;

namespace LibraryMAUIApp;

public partial class PictureBooksPage : ContentPage
{
    private readonly IPictureBookClient _pictureBookClient;
    public PictureBooksPage(BooksViewModel vm)
	{
        _pictureBookClient = new PictureBookClient(App.Configuration, new System.Net.Http.HttpClient());
        InitializeComponent();
        BindingContext = vm;
        GetBooksAsync();
	}
    private async void GetBooksAsync()
    {
        var books = await _pictureBookClient.ListAsync();
        BooksCollectionView.ItemsSource = books.ToList();
    }
}