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

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<DataDto>(jsondata);
            
            return View(value.Data);
        }
        
        return View();
    }
    
    [HttpGet]
    public PartialViewResult Content()
    {
        
        return PartialView();
    }
}