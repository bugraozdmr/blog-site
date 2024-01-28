namespace BlogSite.Mvc.Dtos.DefaultDto;

public class CreatePostDto
{ 
    public string Title { get; set; }
    public string secondaryTitle { get; set; }
    
    public string Author { get; set; }
    
    
    public string ImageMain { get; set; }
    public string ImageSecondary { get; set; }
    
    public string Content { get; set; }
}