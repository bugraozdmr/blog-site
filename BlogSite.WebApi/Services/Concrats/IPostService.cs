using System.Dynamic;
using Entities.DataTransferObjects;
using Entities.MetaData;
using Entities.RequestFeatures;

namespace Services.Concrats;

public interface IPostService
{
    Task<(IEnumerable<ExpandoObject> posts, MetaData metadata)> GetAllPostsAsync(
        PostParameters postParemeters, bool trackChanges);

    Task<PostDto> GetOnePostByIdAsync(int id, bool trackChanges);
    Task<PostDto> CreateOnePostAsync(PostDtoForInsertion post);
    Task UpdateOnePostAsync(int id, PostDtoForUpdate postDto, bool trackChanges);
    Task DeleteOnePostAsync(int id, bool trackChanges);
}