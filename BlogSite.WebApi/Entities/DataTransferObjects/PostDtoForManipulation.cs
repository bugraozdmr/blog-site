using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public abstract record PostDtoForManipulation
{
    [Required(ErrorMessage = "Title is required field")]
    [MinLength(2,ErrorMessage = "Title must contain at least 2 characters")]
    [MaxLength(80,ErrorMessage = "Title can contain max 80 characters")]
    public string Title { get; init; }

    [Required(ErrorMessage = "Content is required field")]
    [MinLength(10,ErrorMessage = "Content must contain at least 10 characters")]
    [MaxLength(1000,ErrorMessage = "Content can contain max 1000 characters")]
    public string Content { get; init; }
    
    [Required(ErrorMessage = "Content is required field")]
    [MinLength(10,ErrorMessage = "Content must contain at least 10 characters")]
    [MaxLength(150,ErrorMessage = "Content can contain max 150 characters")]
    public string secondaryTitle { get; set; }
    
    [Required(ErrorMessage = "Author is required field")]
    public string Author { get; init; }
}