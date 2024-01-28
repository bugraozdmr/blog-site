using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class AboutController : Controller
{
    [HttpGet("about")]
    [HttpGet("about/index")]
    public IActionResult Index()
    {
        return View();
    }
}