namespace Entities.MetaData;

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    
    // true false dönecek - readonlyler
    public bool HasPrevious => CurrentPage > 1 ;
    public bool HasPage => CurrentPage < TotalPage;
}