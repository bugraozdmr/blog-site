using System.Linq.Dynamic.Core;
using Entities.Models;

namespace DefaultNamespace.Extensions;

public static class PostRepositoryExtensions
{
    // buraya filter gelecek zamana göre ...
    // public static IQueryable<Post> FilterPosts(this IQueryable<Post> posts); 

    public static IQueryable<Post> Search(this IQueryable<Post> posts,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return posts;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return posts
            .Where(b => b.Title.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Post> Sort(this IQueryable<Post> posts,
        string orderByQueryString)
    {
        if (!string.IsNullOrWhiteSpace(orderByQueryString))
            return posts.OrderBy(b => b.Id);

        var orderQuery = orderQueryBuilder.CreateOrderQuery<Post>(orderByQueryString);

        if (orderQuery is null)
            return posts.OrderBy(b => b.Id);

        return posts.OrderBy(orderQuery);
    }
}