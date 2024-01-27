using Entities.Models;
using Entities.RequestFeatures;

namespace DefaultNamespace;

public interface IPostRepository
{
    Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters,
        bool trackChanges);

    Task<Post> GetOnePostByidAsync(int id, bool trackChanges);
    void CreateOnePost(Post post);
    void UpdateOnePost(Post post);
    void DeleteOnePost(Post post);
}