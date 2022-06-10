using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface IMagazineService
    {
        int Add(MagazineBookModel book);
        void Delete(int id);
        MagazineBookModel Get(int id);
        IList<MagazineBookModel> List();
        IEnumerable ListNames();
        int Update(MagazineBookModel model);
    }
}