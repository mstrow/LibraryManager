using DataAccessLayer.Models;
using System.Collections;

namespace DataAccessLayer
{
    public interface ILibraryRepository
    {
        void Add(Library instance);
        void Delete(int id);
        void Delete(Library instance);
        Library Get(int id);
        IEnumerable List();
        void Update(Library instance);
    }
}