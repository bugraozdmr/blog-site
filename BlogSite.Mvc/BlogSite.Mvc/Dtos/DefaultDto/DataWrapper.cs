namespace BlogSite.Mvc.Dtos.DefaultDto;

public class DataWrapper
{
    public List<MainDto> Data { get; set; }
    public int pagesize { get; set; }
    public int pagenumber { get; set; }
    public string? query { get; set; }
}