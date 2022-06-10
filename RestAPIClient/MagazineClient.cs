using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class MagazineClient : ClientBase, IMagazineClient
    {
        public MagazineClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<MagazineBookModel> GetAsync(int id)
        {
            return await GetAsync<MagazineBookModel>($"/api/magazine/{id}");
        }

        public async Task<IList<MagazineBookModel>> ListAsync()
        {
            return await GetAsync<IList<MagazineBookModel>>("/api/magazine");
        }

        public async Task<int> AddAsync(MagazineBookModel model)
        {
            return await AddAsync("/api/magazine", model);
        }

        public async Task<int> UpdateAsync(MagazineBookModel model)
        {
            return await UpdateAsync("/api/magazine", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/magazine/{id}");
        }
    }
}
