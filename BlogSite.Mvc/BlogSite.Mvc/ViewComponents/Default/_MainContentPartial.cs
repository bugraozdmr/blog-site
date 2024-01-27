using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _MainContentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}