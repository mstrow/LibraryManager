
using LibraryMAUIApp.ViewModel;
using RestAPIClient;

namespace LibraryMAUIApp;

public partial class NovelsPage : ContentPage
{
    private readonly INovelClient _novelClient;
    public NovelsPage(BooksViewModel vm)
	{
        _novelClient = new NovelClient(App.Configuration, new System.Net.Http.HttpClient());
        InitializeComponent();
        BindingContext = vm;
        GetBooksAsync();
	}
    private async void GetBooksAsync()
    {
        var books = await _novelClient.ListAsync();
        BooksCollectionView.ItemsSource = books.ToList();
    }

}