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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LibraryWinUIApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PictureBooksPage : Page
    {
        private readonly IPictureBookClient _pictureBookClient;
        private SelectedBook SelectedBook;
        public PictureBooksPage()
        {
            _pictureBookClient = new PictureBookClient(App.Configuration, new System.Net.Http.HttpClient());
            this.InitializeComponent();
            this.SelectedBook = new SelectedBook();
            GetBooksAsync();
        }

        private async void GetBooksAsync()
        {
            LoadingProgressRing.IsActive = true;
            var books = await _pictureBookClient.ListAsync();
            BookListView.ItemsSource = books.ToList();
            TotalTextBlock.Text = "Total: " + books.Count.ToString();
            if (books.Count >= 1)
            {
                BookListView.SelectedIndex = 0;
                SelectedBook.Book = BookListView.SelectedItem as PictureBookModel;
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
            }
            LoadingProgressRing.IsActive = false;

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            GetBooksAsync();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BookDialog dialog = new BookDialog(new BookModel());
            dialog.XamlRoot = this.XamlRoot;
            await dialog.ShowAsync();
            GetBooksAsync();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Are you sure you want to delete Book: " + SelectedBook.Book.Title + "?";
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Yes";
            dialog.CloseButtonText = "No";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                _pictureBookClient.DeleteAsync(SelectedBook.Book.ID);
                GetBooksAsync();
            }
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            BookDialog dialog = new BookDialog(SelectedBook.Book);
            dialog.XamlRoot = this.XamlRoot;
            await dialog.ShowAsync();
            GetBooksAsync();
        }

        private void BookListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SelectedBook.Book = ((ListView)sender).SelectedValue as PictureBookModel;
        }
    }
}
