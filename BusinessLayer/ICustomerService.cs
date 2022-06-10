using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface ICustomerService
    {
        int Add(CustomerModel customer);
        void Delete(int id);
        CustomerModel Get(int id);
        IList<CustomerModel> List();
        IEnumerable ListNames();
        int Update(CustomerModel model);
    }
}