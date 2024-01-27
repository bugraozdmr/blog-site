namespace Entities.DataTransferObjects;

public record PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string secondaryTitle { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    // REPLACE TR KARAKTER YAZ
    public string Slug => $"{Title.Replace(' ', '-').ToLower()}-{Id}";

    public PostDto()
    {
        CreatedAt = DateTime.UtcNow;
    }
}