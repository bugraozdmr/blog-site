using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultNamespace.Config;

public class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(
            new Post
            {
                Author = "grant", Content = "dkwqdlwqdlqw", secondaryTitle = "what biden did",
                CreatedAt = DateTime.UtcNow, Id = 1, Slug = "what-biden-did",Title = "sdqdwq",
                ImageMain = "#",ImageSecondary = "#"
            },
            new Post
            {
                Author = "grant", Content = "dkwqdlwqdlqw", secondaryTitle = "what biden did",
                CreatedAt = DateTime.UtcNow, Id = 2, Slug = "what-biden-did",Title = "wrfqwr",
                ImageMain = "#",ImageSecondary = "#"
            },
            new Post
            {
                Author = "grant", Content = "dkwqdlwqdlqw", secondaryTitle = "what biden did",
                CreatedAt = DateTime.UtcNow, Id = 3, Slug = "what-biden-did",Title = "fewfwe",
                ImageMain = "#",ImageSecondary = "#"
            });
    }
}