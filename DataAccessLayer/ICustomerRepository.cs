using DataAccessLayer.Models;
using System.Collections;

namespace DataAccessLayer
{
    public interface ICustomerRepository
    {
        void Add(Customer instance);
        void Delete(Customer instance);
        void Delete(int id);
        Customer Get(int id);
        IEnumerable List();
        void Update(Customer instance);
    }
}