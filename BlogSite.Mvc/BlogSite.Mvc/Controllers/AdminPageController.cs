using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class AdminPageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}