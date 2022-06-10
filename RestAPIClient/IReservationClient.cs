using Models;

namespace RestAPIClient
{
    public interface IReservationClient
    {
        Task<int> AddAsync(ReservationModel model);
        void DeleteAsync(int id);
        Task<ReservationModel> GetAsync(int id);
        Task<IList<ReservationModel>> ListAsync();
        Task<int> UpdateAsync(ReservationModel model);
    }
}