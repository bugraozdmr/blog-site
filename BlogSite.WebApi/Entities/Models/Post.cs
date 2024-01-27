namespace Entities.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string secondaryTitle { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public string ImageMain { get; set; }
    public string ImageSecondary { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    // REPLACE TR KARAKTER YAZ
    public string? Slug { get; set; }
}