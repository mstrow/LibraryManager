using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

    LoggerFactory _myLoggerFactory =
    new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });

var connectionstring = @"Server=localhost;Database=LibraryDB;Uid=admin;Pwd=pofAizW6KbVWy3pW6Snd9kZchtwGYz;";

var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
optionsBuilder.UseMySQL(connectionstring);
optionsBuilder.UseLoggerFactory(_myLoggerFactory);
optionsBuilder.LogTo(Console.WriteLine);

/*using (var context = new ModelContext(optionsBuilder.Options))
{
    using (var unitOfWork = new Transaction(context))
    {
        var libraryRepository = new LibraryRepository(context);

        //var books = unitOfWork.Books.List();

        foreach (Library library in libraryRepository.List())
        {
            foreach (Book book in library.Books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}*/
ModelContext model = new ModelContext(optionsBuilder.Options);
Transaction trans = new Transaction(model);
INovelService bookService = new NovelService(trans);

/*ICustomerService customerService = new CustomerService(trans);

IReservationService reservationService = new ReservationService(trans);

ILibraryService libraryService = new LibraryService(trans);

foreach (ReservationModel reservation in reservationService.List())
{
    Console.WriteLine(reservation.Date.ToString());
}*/


//Console.WriteLine(bookService.Get(3).Title);

foreach (IBookModel books in bookService.List())
{
    Console.WriteLine(books.Title);
}

/*Console.WriteLine(customerService.Get(2).Name);

//Console.WriteLine(libraryService.Get(1).Name);
var libraryList = libraryService.List();
foreach (LibraryModel library in libraryList)
{
    foreach (IBookModel book in library.Books)
    {
        Console.WriteLine(book.Title);
    }
}
*/
