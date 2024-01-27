using System.Dynamic;
using AutoMapper;
using DefaultNamespace;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.MetaData;
using Entities.Models;
using Entities.RequestFeatures;
using Services.Concrats;

namespace Services;

public class PostManager : IPostService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    private readonly IDataShaper<PostDto> _shaper;

    public PostManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<PostDto> shaper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
        _shaper = shaper;
    }


    public async Task<(IEnumerable<ExpandoObject> posts, MetaData metadata)> GetAllPostsAsync(PostParameters postParemeters, bool trackChanges)
    {
        // buraya bir filter gömülecek -- exception tanımlanıp
        
        var booksWithMetaData = await _manager
            .Post
            .GetAllPostsAsync(postParemeters, trackChanges);

        var postsDto = _mapper.Map<IEnumerable<PostDto>>(booksWithMetaData);

        var shapedData = _shaper.ShapeData(postsDto, postParemeters.Fields);

        return (shapedData, booksWithMetaData.MetaData);
    }

    public async Task<PostDto> GetOnePostByIdAsync(int id, bool trackChanges)
    {
        var post = await GetOneBookAndCheckExists(id, trackChanges);
        return _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> CreateOnePostAsync(PostDtoForInsertion post)
    {
        var entity = _mapper.Map<Post>(post);
        
        _manager.Post.CreateOnePost(entity);
        _manager.SaveAsync();

        return _mapper.Map<PostDto>(entity);
    }

    public async Task UpdateOnePostAsync(int id, PostDtoForUpdate postDto, bool trackChanges)
    {
        var entity = await GetOneBookAndCheckExists(id, trackChanges);

        entity = _mapper.Map<Post>(postDto);
        
        _manager.Post.UpdateOnePost(entity);

        await _manager.SaveAsync();
    }

    public async Task DeleteOnePostAsync(int id, bool trackChanges)
    {
        var entity = await GetOneBookAndCheckExists(id, trackChanges);
        
        _manager.Post.DeleteOnePost(entity);

        await _manager.SaveAsync();
    }
    
    
    private async Task<Post> GetOneBookAndCheckExists(int id,bool trackChanges) {
        // check entity
        var entity = await _manager.Post.GetOnePostByidAsync(id, trackChanges);

        if (entity is null)
        {
            throw new PostNotFoundException(id);
        }

        return entity;
    }
}