using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class UpdatePanelController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}