namespace BlogSite.Mvc.Dtos.DefaultDto;

public class MainDto
{
    
    public string Title { get; set; }
    public string secondaryTitle { get; set; }
    
    public string Author { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    // REPLACE TR KARAKTER YAZ
    public string? Slug { get; set; }
}