namespace BlogSite.Mvc.Dtos.DefaultDto;

public class ListAndOnePostDto
{
    public MainDto Data { get; set; }
    public List<MainDto> Datas { get; set; }
}