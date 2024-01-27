using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}