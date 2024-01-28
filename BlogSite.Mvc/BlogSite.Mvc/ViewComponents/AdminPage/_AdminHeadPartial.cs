
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.AdminPage;

public class _AdminHeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}