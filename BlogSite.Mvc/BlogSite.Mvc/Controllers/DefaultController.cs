using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}