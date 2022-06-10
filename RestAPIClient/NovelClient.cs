using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class NovelClient : ClientBase, INovelClient
    {
        public NovelClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<NovelBookModel> GetAsync(int id)
        {
            return await GetAsync<NovelBookModel>($"/api/novel/{id}");
        }

        public async Task<IList<NovelBookModel>> ListAsync()
        {
            return await GetAsync<IList<NovelBookModel>>("/api/novel");
        }

        public async Task<int> AddAsync(NovelBookModel model)
        {
            return await AddAsync("/api/novel", model);
        }

        public async Task<int> UpdateAsync(NovelBookModel model)
        {
            return await UpdateAsync("/api/novel", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/novel/{id}");
        }
    }
}
