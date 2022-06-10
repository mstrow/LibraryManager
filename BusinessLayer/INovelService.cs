using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface INovelService
    {
        int Add(NovelBookModel book);
        void Delete(int id);
        NovelBookModel Get(int id);
        IList<NovelBookModel> List();
        IEnumerable ListNames();
        int Update(NovelBookModel model);
    }
}