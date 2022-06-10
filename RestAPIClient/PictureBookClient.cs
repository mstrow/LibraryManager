using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class PictureBookClient : ClientBase, IPictureBookClient
    {
        public PictureBookClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<PictureBookModel> GetAsync(int id)
        {
            return await GetAsync<PictureBookModel>($"/api/picturebook/{id}");
        }

        public async Task<IList<PictureBookModel>> ListAsync()
        {
            return await GetAsync<IList<PictureBookModel>>("/api/picturebook");
        }

        public async Task<int> AddAsync(PictureBookModel model)
        {
            return await AddAsync("/api/picturebook", model);
        }

        public async Task<int> UpdateAsync(PictureBookModel model)
        {
            return await UpdateAsync("/api/picturebook", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/picturebook/{id}");
        }
    }
}
