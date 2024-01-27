using Entities.Models;

namespace DefaultNamespace;

public interface IPostRepository
{
    Task<PagedList<Post>> GetAllBooksAsync(BookPareters bookPareters,
        bool trackChanges);

    Task<Post> GetOneBookByidAsync(int id, bool trackChanges);
    void CreateOneBook(Post book);
    void UpdateOneBook(Post book);
    void DeleteOneBook(Post book);
}