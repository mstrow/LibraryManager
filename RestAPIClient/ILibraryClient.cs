using Models;

namespace RestAPIClient
{
    public interface ILibraryClient
    {
        Task<int> AddAsync(LibraryModel model);
        void DeleteAsync(int id);
        Task<LibraryModel> GetAsync(int id);
        Task<IList<LibraryModel>> ListAsync();
        Task<int> UpdateAsync(LibraryModel model);
    }
}