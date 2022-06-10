using DataAccessLayer.Models;
using System.Collections;

namespace DataAccessLayer
{
    public interface IBookRepository
    {
        void Add(Book instance);
        void Delete(Book instance);
        void Delete(int id);
        Book Get(int id);
        IEnumerable List<T>();
        IEnumerable<T> List<T>(int artistID);
        void Update(Book instance);
    }
}