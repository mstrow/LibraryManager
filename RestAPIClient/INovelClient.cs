using Models;

namespace RestAPIClient
{
    public interface INovelClient
    {
        Task<int> AddAsync(NovelBookModel model);
        void DeleteAsync(int id);
        Task<NovelBookModel> GetAsync(int id);
        Task<IList<NovelBookModel>> ListAsync();
        Task<int> UpdateAsync(NovelBookModel model);
    }
}