using System.ComponentModel.DataAnnotations;

namespace BlogSite.Mvc.Dtos.DefaultDto;

public class CreatePostDto
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "Başlık kısmı zorunlu alandır")]
    [MinLength(2,ErrorMessage = "Başlık kısmı en az 2 karakter olabilir")]
    [MaxLength(200,ErrorMessage = "Başlık kısmı en fazla 200 karakter olabilir")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Yardımcı başlık kısmı zorunlu alandır")]
    [MinLength(10,ErrorMessage = "Yardımcı başlık en az 10 karakter olabilir")]
    [MaxLength(300,ErrorMessage = "Yardımcı başlık en fazla 300 karakter olabilir")]
    public string secondaryTitle { get; set; }
    
    [Required(ErrorMessage = "Yazar kısmı zorunlu alandır")]
    public string Author { get; set; }
    
    [Required(ErrorMessage = "Resim kısmı zorunlu alandır")]
    public string ImageMain { get; set; }
    [Required(ErrorMessage = "Yardımcı resim kısmı zorunlu alandır")]
    public string ImageSecondary { get; set; }
    
    [Required(ErrorMessage = "Başlık kısmı zorunlu alandır")]
    [MinLength(10,ErrorMessage = "Açıklama kısmı en az 10 karakter olabilir")]
    [MaxLength(1500,ErrorMessage = "Açıklama kısmı en fazla 1500 karakter olabilir")]
    public string Content { get; set; }
}