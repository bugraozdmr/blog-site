namespace BlogSite.Mvc.Dtos.DefaultDto;

public class MainDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string secondaryTitle { get; set; }
    
    public string Author { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    public string? Slug { get; set; }
    
    public string ImageMain { get; set; }
    public string ImageSecondary { get; set; }
    
    public string Content { get; set; }
}