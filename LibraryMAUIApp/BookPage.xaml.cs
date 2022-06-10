using LibraryMAUIApp.ViewModel;

namespace LibraryMAUIApp;

public partial class BookPage : ContentPage
{
	public BookPage(BookViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}