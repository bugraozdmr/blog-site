using Repositories.EFCore;

namespace DefaultNamespace;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IPostRepository> _postRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _postRepository = new Lazy<IPostRepository>(() => new PostRepository(_context));
    }

    public IPostRepository Post => _postRepository.Value;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}