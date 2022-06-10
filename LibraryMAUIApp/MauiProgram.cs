using LibraryMAUIApp.ViewModel;

namespace LibraryMAUIApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<NovelsPage>();
            builder.Services.AddSingleton<MagazinesPage>();
            builder.Services.AddSingleton<PictureBooksPage>();
            builder.Services.AddSingleton<BooksViewModel>();

            builder.Services.AddSingleton<BookPage>();
            builder.Services.AddSingleton<BookViewModel>();
            return builder.Build();
        }
    }
}