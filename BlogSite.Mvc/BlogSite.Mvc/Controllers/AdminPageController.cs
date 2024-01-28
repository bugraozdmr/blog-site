using BlogSite.Mvc.Dtos.DefaultDto;
using BlogSite.Mvc.Dtos.PostDataDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Mvc.Controllers;

public class AdminPageController : Controller
{
    
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminPageController(IHttpClientFactory client)
    {
        _httpClientFactory = client;
    }

    
    [HttpGet("adminpage/index")]
    [HttpGet("adminpage")]
    public async Task<IActionResult> Index(int pagesize,int pagenumber)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7052/api/post/getAllPosts?pagesize={pagesize}&pagenumber={pagenumber}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<DataWrapper>(jsonData);
            return View(values.Data);
        }
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> updatepost(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7052/api/post/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<MainDto>(jsondata);

            return View(values);
        }
        return View();
    }
    
    
    [HttpGet]
    public PartialViewResult AllPosts()
    {
        return PartialView();
    }
    
    
}