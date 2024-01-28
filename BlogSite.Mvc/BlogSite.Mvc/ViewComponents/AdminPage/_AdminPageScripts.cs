using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.AdminPage;

public class _AdminPageScripts : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}