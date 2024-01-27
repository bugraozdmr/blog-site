using BlogSite.Mvc.Dtos.DefaultDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class PostPage : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PostPage(IHttpClientFactory client)
    {
        _httpClientFactory = client;
    }

    
    
    [HttpGet("{slug}")]
    public async Task<IActionResult> Index(string slug)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7052/api/post/getAllPosts?pagesize=9&pagenumber=1");

        
        return View();
    }
    
    [HttpGet]
    public PartialViewResult Content()
    {
        
        return PartialView();
    }
}