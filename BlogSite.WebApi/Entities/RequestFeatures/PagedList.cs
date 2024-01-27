namespace Entities.RequestFeatures;

public class PagedList<T> : List<T>
{
    public MetaData.MetaData MetaData { get; set; }

    public PagedList(List<T> items,int count,int pageNumber,int PageSize)
    {
        MetaData = new MetaData.MetaData()
        {
            CurrentPage = pageNumber,
            TotalPage = (int)Math.Ceiling(count / (double)PageSize),
            PageSize = PageSize,
            TotalCount = count
        };
        
        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}