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

    public async Task<PostDto> GetOnePostFromSlug(string slug, bool trackChanges)
    {
        var entity = await _manager.Post.GetPostFromSlug(slug, trackChanges);

        if (entity is null)
        {
            throw new PostNotFoundException(404);
        }

        return _mapper.Map<PostDto>(entity);
    }
    
    public async Task<PostDto> CreateOnePostAsync(PostDtoForInsertion post)
    {
        post.CreatedAt = DateTime.Now;
        post.Slug = $"{RemoveNonAlphanumericAndSpecialChars(ReplaceTurkishCharacters(post.Title.Replace(' ', '-').ToLower()))}.{GenerateUniqueHash()}";
        
        var entity = _mapper.Map<Post>(post);

        _manager.Post.CreateOnePost(entity);
        await _manager.SaveAsync();


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
    
    private static string GenerateUniqueHash()
    {
        string guid = Guid.NewGuid().ToString("N");

        
        int length = 6;
        if (guid.Length < length)
        {
            length = guid.Length;
        }

        string uniqueHash = guid.Substring(0, length);

        return uniqueHash;
    }
    
    private string ReplaceTurkishCharacters(string input)
    {
        input = input.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");
        input = input.Replace("İ", "i").Replace("Ğ", "g").Replace("Ü", "u").Replace("Ş", "s").Replace("Ö", "o").Replace("Ç", "c");
        return input;
    }
    
    private string RemoveNonAlphanumericAndSpecialChars(string input)
    {
        // LINQ kullanarak boşluk, tire ve nokta karakterlerini filtrele
        var filteredCharacters = input
            .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-')
            .ToArray();

        // Filtrelenmiş karakterleri yeni bir string olarak oluştur
        string result = new string(filteredCharacters);

        return result;
    }


}