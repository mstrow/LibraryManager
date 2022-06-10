using Models;

namespace RestAPIClient
{
    public interface IPictureBookClient
    {
        Task<int> AddAsync(PictureBookModel model);
        void DeleteAsync(int id);
        Task<PictureBookModel> GetAsync(int id);
        Task<IList<PictureBookModel>> ListAsync();
        Task<int> UpdateAsync(PictureBookModel model);
    }
}