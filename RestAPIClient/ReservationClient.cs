using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestAPIClient
{
    public class ReservationClient : ClientBase, IReservationClient
    {
        public ReservationClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
        {

        }

        public async Task<ReservationModel> GetAsync(int id)
        {
            return await GetAsync<ReservationModel>($"/api/reservation/{id}");
        }

        public async Task<IList<ReservationModel>> ListAsync()
        {
            return await GetAsync<IList<ReservationModel>>("/api/reservation");
        }

        public async Task<int> AddAsync(ReservationModel model)
        {
            return await AddAsync("/api/reservation", model);
        }

        public async Task<int> UpdateAsync(ReservationModel model)
        {
            return await UpdateAsync("/api/reservation", model);
        }

        public void DeleteAsync(int id)
        {
            DeleteAsync($"/api/reservation/{id}");
        }
    }
}
