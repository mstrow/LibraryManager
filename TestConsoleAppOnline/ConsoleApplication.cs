using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIClient;

namespace TestConsoleAppOnline
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly ILibraryClient _libraryClient;

        public ConsoleApplication(ILibraryClient libraryClient)
        {
            _libraryClient = libraryClient;
        }

        public void Run()
        {
            Console.ReadKey();
            Console.WriteLine("Start");
            LoadLibraries();
            Console.WriteLine("End");
            Console.ReadKey();
        }
        public async void LoadLibraries()
        {
            Console.WriteLine("Called await _artistClient.GetAsync(1)");
            var library = await _libraryClient.GetAsync(2);
            Console.WriteLine($"GetAsync returned with {library.Name}");
            Console.WriteLine($"Listing works");
            Console.WriteLine(library.Name);
            foreach (var book in library.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
