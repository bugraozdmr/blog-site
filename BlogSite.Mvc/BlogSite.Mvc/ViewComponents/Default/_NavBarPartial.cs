using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _NavBarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}