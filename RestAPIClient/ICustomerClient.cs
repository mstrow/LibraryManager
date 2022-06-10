using Models;

namespace RestAPIClient
{
    public interface ICustomerClient
    {
        Task<int> AddAsync(CustomerModel model);
        void DeleteAsync(int id);
        Task<CustomerModel> GetAsync(int id);
        Task<IList<CustomerModel>> ListAsync();
        Task<int> UpdateAsync(CustomerModel model);
    }
}