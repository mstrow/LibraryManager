using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface IPictureBookService
    {
        int Add(PictureBookModel book);
        void Delete(int id);
        PictureBookModel Get(int id);
        IList<PictureBookModel> List();
        IEnumerable ListNames();
        int Update(PictureBookModel model);
    }
}