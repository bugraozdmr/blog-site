namespace Entities.RequestFeatures;

public class PostParameters : RequestParameters
{
    //public uint MinPrice { get; set; }        // gerekli olanlar gelecek
    //public uint MaxPrice { get; set; } = 1000;
    //public bool ValidPriceRange => MaxPrice > MinPrice;
    public string? SearchTerm { get; set; }


    public PostParameters()
    {
        OrderBy = "id";
    }
}