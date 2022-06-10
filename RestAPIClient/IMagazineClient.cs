using Models;

namespace RestAPIClient
{
    public interface IMagazineClient
    {
        Task<int> AddAsync(MagazineBookModel model);
        void DeleteAsync(int id);
        Task<MagazineBookModel> GetAsync(int id);
        Task<IList<MagazineBookModel>> ListAsync();
        Task<int> UpdateAsync(MagazineBookModel model);
    }
}