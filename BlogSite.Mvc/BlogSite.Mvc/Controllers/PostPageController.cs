using BlogSite.Mvc.Dtos.DefaultDto;
using BlogSite.Mvc.Dtos.PostDataDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Mvc.Controllers;

public class PostPageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PostPageController(IHttpClientFactory client)
    {
        _httpClientFactory = client;
    }

    
    
    [HttpGet("{slug}")]
    public async Task<IActionResult> Index(string slug)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7052/api/post/get/{slug}");

        var recentlyCreated = await client.GetAsync("https://localhost:7052/api/post/getAllPosts?orderBy=id%20desc");
        
        if (responseMessage.IsSuccessStatusCode && recentlyCreated.IsSuccessStatusCode)
        {
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<DataDto>(jsondata);

            var jsondata1 = await recentlyCreated.Content.ReadAsStringAsync();
            var value1 = JsonConvert.DeserializeObject<DataWrapper>(jsondata1);

            var newDto = new ListAndOnePostDto()
            {
                Data = value.Data,
                Datas = value1.Data
            };
            
            
            return View(newDto);
        }
        
        return View();
    }
    
    [HttpGet]
    public PartialViewResult Content()
    {
        
        return PartialView();
    }
}