using Entities.Models;
using Entities.RequestFeatures;

namespace DefaultNamespace;

public interface IPostRepository
{
    Task<PagedList<Post>> GetAllBooksAsync(PostParameters postParameters,
        bool trackChanges);

    Task<Post> GetOneBookByidAsync(int id, bool trackChanges);
    void CreateOneBook(Post post);
    void UpdateOneBook(Post post);
    void DeleteOneBook(Post post);
}