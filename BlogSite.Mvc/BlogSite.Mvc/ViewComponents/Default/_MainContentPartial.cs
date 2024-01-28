using BlogSite.Mvc.Dtos.DefaultDto;
using BlogSite.Mvc.Dtos.RouteParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BlogSite.Mvc.ViewComponents.Default;

public class _MainContentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _MainContentPartial(IHttpClientFactory client)
    {
        _httpClientFactory = client;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync(FromRouteDto dto)
    {
        Console.WriteLine($"{dto.pagesize}-{dto.pagenumber}");
        
        if (dto.pagesize == 0 && dto.pagenumber == 0)
        {
            dto.pagesize = 5;
            dto.pagenumber = 1;
        }
        
        var client = _httpClientFactory.CreateClient();
        
        var responseMessage = await client.GetAsync($"https://localhost:7052/api/post/getAllPosts?pagesize={dto.pagesize}&pagenumber={dto.pagenumber}");

        if (!string.IsNullOrEmpty(dto.query))
        {
            responseMessage = await client.GetAsync($"https://localhost:7052/api/post/getAllPosts?pagesize={dto.pagesize}&pagenumber={dto.pagenumber}&searchTerm={dto.query}");
        }
        
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<DataWrapper>(jsonData);
            values.pagenumber = dto.pagenumber;
            values.pagesize = dto.pagesize;
            return View(values);
        }
        return View();
    }
}