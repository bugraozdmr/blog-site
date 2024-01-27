namespace DefaultNamespace;

public interface IRepositoryManager
{
    IPostRepository Post { get; }
    Task SaveAsync();
}