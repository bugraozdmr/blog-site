using System.Text;
using AutoMapper;
using BlogSite.Mvc.Dtos.DefaultDto;
using BlogSite.Mvc.Dtos.PostDataDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogSite.Mvc.Controllers;

public class AdminPageController : Controller
{
    
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    public AdminPageController(IHttpClientFactory client,IMapper mapper)
    {
        _httpClientFactory = client;
        _mapper = mapper;
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

    // eğer gitmiyorsa isimleri kontrol et !
    [HttpGet]
    public async Task<IActionResult> createpost()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> createpost(CreatePostDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(dto);
        
        
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");

        
        var responseMessage = await client.PostAsync("https://localhost:7052/api/post", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        
        Console.WriteLine(responseMessage.StatusCode);
        Console.WriteLine(responseMessage.Content);
        
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
            var values = JsonConvert.DeserializeObject<DataDto>(jsondata);

            return View(values.Data);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> updatepost(MainDto model)
    {
        var client = _httpClientFactory.CreateClient();

        var updateDto = _mapper.Map<UpdatePostDto>(model);
        
        var jsonData = JsonConvert.SerializeObject(updateDto);
        StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        
        
        var responseMessage = await client.PutAsync($"https://localhost:7052/api/post/{model.Id}", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public async Task<IActionResult> deletepost(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7052/api/post/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        return View("Index");
    }   
    
    
    
    [HttpGet]
    public PartialViewResult AllPosts()
    {
        return PartialView();
    }
    
    
}