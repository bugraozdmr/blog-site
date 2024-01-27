using BlogSite.Mvc.Dtos.DefaultDto;
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
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7052/api/post/getAllPosts?pagesize=9&pagenumber=1");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<DataWrapper>(jsonData);
            return View(values.Data);
        }
        return View();
    }
}