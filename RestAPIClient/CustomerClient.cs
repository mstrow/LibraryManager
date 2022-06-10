using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class CustomerClient : ClientBase, ICustomerClient
    {
        public CustomerClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<CustomerModel> GetAsync(int id)
        {
            return await GetAsync<CustomerModel>($"/api/customer/{id}");
        }

        public async Task<IList<CustomerModel>> ListAsync()
        {
            return await GetAsync<IList<CustomerModel>>("/api/customer");
        }

        public async Task<int> AddAsync(CustomerModel model)
        {
            return await AddAsync("/api/customer", model);
        }

        public async Task<int> UpdateAsync(CustomerModel model)
        {
            return await UpdateAsync("/api/customer", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/customer/{id}");
        }
    }
}
