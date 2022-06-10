using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface ILibraryService
    {
        int Add(LibraryModel library);
        void Delete(int id);
        LibraryModel Get(int id);
        IList<LibraryModel> List();
        IEnumerable ListNames();
        int Update(LibraryModel model);
    }
}