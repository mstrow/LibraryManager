using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Models;


namespace LibraryMAUIApp.ViewModel
{
    public partial class BooksViewModel : ObservableObject
    {
        public BooksViewModel()
        {
        }

        [ICommand]
        async Task Tap(IBookModel b)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                ["Title"] = b.Title,
                ["Isbn"] = b.ISBN,
                ["Year"] = b.Year,
                ["Id"] = b.ID,
                ["Description"] = b.Description,
                ["Author"] = b.Author,
                ["Imageurl"] = b.ImageUrl
            };
            await Shell.Current.GoToAsync($"{nameof(BookPage)}", navigationParameter);
                
        }
    }
}