using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class ContactController : Controller
{
    [HttpGet("contact")]
    [HttpGet("contact/index")]
    public IActionResult Index()
    {
        return View();
    }
}