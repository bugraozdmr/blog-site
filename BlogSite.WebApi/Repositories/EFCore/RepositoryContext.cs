using DefaultNamespace.Config;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfig());
    }
}