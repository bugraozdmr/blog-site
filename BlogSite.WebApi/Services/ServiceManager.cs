using AutoMapper;
using DefaultNamespace;
using Entities.DataTransferObjects;
using Services.Concrats;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPostService> _postService;

    public ServiceManager(
        IRepositoryManager repositoryManager,
        ILoggerService logger,
        IMapper mapper,
        IDataShaper<PostDto> shaper)
    {
        _postService = new Lazy<IPostService>(() => new PostManager(repositoryManager
            ,logger
            ,mapper
            ,shaper));
    }

    public IPostService PostService => _postService.Value;
}