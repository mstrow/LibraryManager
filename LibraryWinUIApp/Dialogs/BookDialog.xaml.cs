using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Models;
using RestAPIClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CommunityToolkit.WinUI.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LibraryWinUIApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookDialog : ContentDialog
    {

        private readonly ILibraryClient _libraryClient;
        private readonly IPictureBookClient _pictureBookClient;
        private readonly INovelClient _novelClient;
        private readonly IMagazineClient _magazineClient;

        private IBookModel _book;
        public DialogResult Result { get; private set; }

        private List<LibraryModel> Libraries = new List<LibraryModel>();

        public BookDialog(IBookModel book)
        {
            _book = book;
            
            _libraryClient = new LibraryClient(App.Configuration, new System.Net.Http.HttpClient());
            _pictureBookClient = new PictureBookClient(App.Configuration, new System.Net.Http.HttpClient());
            _novelClient = new NovelClient(App.Configuration, new System.Net.Http.HttpClient());
            _magazineClient = new MagazineClient(App.Configuration, new System.Net.Http.HttpClient());
            
            this.InitializeComponent();

            
            UpdateLibraries();
            BookTypeComboBox.SelectionChanged += BookTypeComboBox_SelectionChanged;
            

        }

        public async void UpdateLibraries()
        {
            var libraries = await _libraryClient.ListAsync();
            Libraries = libraries.ToList();
            LibraryComboBox.ItemsSource = Libraries;

            if (_book.ISBN != null)
            {
                FillFields(_book);
                this.Title = "Edit: " + _book.ISBN;
                this.PrimaryButtonText = "Edit";
            }

        }
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            if (_book.ISBN != null)
            {
                if (await AddBook())
                {
                    this.Result = DialogResult.OK;
                }
                else
                {
                    this.Result = DialogResult.Fail;
                }
                if (await EditBook())
                {
                    this.Result = DialogResult.OK;
                }
                else
                {
                    this.Result = DialogResult.Fail;
                }
            }
            deferral.Complete();
        }
        private void BookTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SizeTextBox.IsEnabled = false;
            IssueDatePicker.IsEnabled = false;
            PagesTextBox.IsEnabled = false;
            if (BookTypeComboBox.SelectedIndex == 0)
            {
                PagesTextBox.IsEnabled = true;
            }
            else if (BookTypeComboBox.SelectedIndex == 1)
            {
                IssueDatePicker.IsEnabled = true;
            }
            else if (BookTypeComboBox.SelectedIndex == 2)
            {
                SizeTextBox.IsEnabled = true;
            }
        }
        private async Task<bool> AddBook()
        {
            
            if (BookTypeComboBox.SelectedIndex == 0)
            {
                NovelBookModel novelBook = new NovelBookModel();
                novelBook = (NovelBookModel)FillBook(novelBook);
                novelBook.Pages = Int32.Parse(PagesTextBox.Text);
                await _novelClient.AddAsync(novelBook);
            }
            else if (BookTypeComboBox.SelectedIndex == 1)
            {
                MagazineBookModel magazineBook = new MagazineBookModel();
                magazineBook = (MagazineBookModel)FillBook(magazineBook);
                magazineBook.IssueDate = IssueDatePicker.SelectedDate.GetValueOrDefault().DateTime;
                await _magazineClient.AddAsync(magazineBook);
            }
            else if (BookTypeComboBox.SelectedIndex == 2)
            {
                PictureBookModel pictureBook = new PictureBookModel();
                pictureBook = (PictureBookModel)FillBook(pictureBook);
                pictureBook.Size = SizeTextBox.Text;
                await _pictureBookClient.AddAsync(pictureBook);
            }
            return true;
        }
        private async Task<bool> EditBook()
        {
            
            if (BookTypeComboBox.SelectedIndex == 0)
            {
                NovelBookModel novelBook = new NovelBookModel();
                novelBook.ID = _book.ID;
                novelBook = (NovelBookModel)FillBook(novelBook);
                novelBook.Pages = Int32.Parse(PagesTextBox.Text);
                await _novelClient.UpdateAsync(novelBook);
            }
            else if (BookTypeComboBox.SelectedIndex == 1)
            {
                MagazineBookModel magazineBook = new MagazineBookModel();
                magazineBook.ID = _book.ID;
                magazineBook = (MagazineBookModel)FillBook(magazineBook);
                magazineBook.IssueDate = IssueDatePicker.SelectedDate.GetValueOrDefault().DateTime;
                await _magazineClient.UpdateAsync(magazineBook);
            }
            else if (BookTypeComboBox.SelectedIndex == 2)
            {
                PictureBookModel pictureBook = new PictureBookModel();
                pictureBook.ID = _book.ID;
                pictureBook = (PictureBookModel)FillBook(pictureBook);
                pictureBook.Size = SizeTextBox.Text;
                await _pictureBookClient.UpdateAsync(pictureBook);
            }
            return true;
        }
        private IBookModel FillBook(IBookModel book)
        {
            var selectedLibrary = LibraryComboBox.SelectedItem as LibraryModel;
            var title = TitleTextBox.Text;
            var author = AuthorTextBox.Text;
            var year = YearTextBox.Text;
            var cost = CostTextBox.Text;
            var description = DescriptionTextBox.Text;
            var isbn = IsbnTextBox.Text;
            book.Author = author;
            book.ISBN = isbn;
            book.Title = title;
            book.Year = Int32.Parse(year);
            book.Cost = Convert.ToDecimal(cost);
            book.Description = description;
            book.LibraryID = selectedLibrary.ID;
            book.LastModified = DateTime.Now;
            return book;
        }

        private void FillFields(IBookModel book)
        {
            LibraryComboBox.SelectedItem = LibraryComboBox.Items.Cast<LibraryModel>().Where(i => i.ID == book.LibraryID);

            if(book is NovelBookModel)
            {
                BookTypeComboBox.SelectedIndex = 0;
                PagesTextBox.Text = (book as NovelBookModel).Pages.ToString();
            }
            else if(book is MagazineBookModel)
            {
                BookTypeComboBox.SelectedIndex = 1;
                try
                {
                    IssueDatePicker.Date = (DateTimeOffset)(book as MagazineBookModel).IssueDate;
                }
                catch
                {
                    IssueDatePicker.Date = (DateTimeOffset)DateTime.Now;
                }
            }
            else
            {
                BookTypeComboBox.SelectedIndex = 2;
                try
                {
                    SizeTextBox.Text = (book as PictureBookModel).Size;
                }
                catch
                {
                    SizeTextBox.Text = "";
                }
            }
            TitleTextBox.Text = book.Title;
            AuthorTextBox.Text = book.Author;
            YearTextBox.Text = book.Year.ToString();
            CostTextBox.Text = book.Cost.ToString();
            DescriptionTextBox.Text = book.Description;
            IsbnTextBox.Text = book.ISBN;
        }


        private void IsbnTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!TextBoxExtensions.GetIsValid(IsbnTextBox))
            {
                IsbnTeachingTip.IsOpen = true;
            }
        }

        private void CostTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!TextBoxExtensions.GetIsValid(CostTextBox))
            {
                CostTeachingTip.IsOpen = true;
            }
        }

        private void PagesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!TextBoxExtensions.GetIsValid(PagesTextBox))
            {
                PageTeachingTip.IsOpen = true;
            }
        }
    }
}
