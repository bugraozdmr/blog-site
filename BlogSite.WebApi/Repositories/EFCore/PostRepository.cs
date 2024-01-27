using DefaultNamespace.Extensions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace DefaultNamespace;

public sealed class PostRepository : RepositoryBase<Post> , IPostRepository
{
    public PostRepository(RepositoryContext context) : base(context)
    {
        
    }


    public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
    {
        
        // sonra filter eklenecek
        var posts = await FindAll(trackChanges)
            .Sort(postParameters.OrderBy)
            .Search(postParameters.SearchTerm)
            .ToListAsync();

        return PagedList<Post>
            .ToPagedList(posts,
                postParameters.PageNumber,
                postParameters.PageSize);
    }

    public async Task<Post> GetOnePostByidAsync(int id, bool trackChanges) => 
        await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateOnePost(Post post) => Create(post);

    public void UpdateOnePost(Post post) => Update(post);

    public void DeleteOnePost(Post post) => Delete(post);
}