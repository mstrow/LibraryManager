using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class LibraryClient : ClientBase, ILibraryClient
    {
        public LibraryClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<LibraryModel> GetAsync(int id)
        {
            return await GetAsync<LibraryModel>($"/api/library/{id}");
        }

        public async Task<IList<LibraryModel>> ListAsync()
        {
            return await GetAsync<IList<LibraryModel>>("/api/library");
        }

        public async Task<int> AddAsync(LibraryModel model)
        {
            return await AddAsync("/api/library", model);
        }

        public async Task<int> UpdateAsync(LibraryModel model)
        {
            return await UpdateAsync("/api/library", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/library/{id}");
        }
    }
}
