using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class PostPage : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public PartialViewResult Content()
    {
        return PartialView();
    }
}