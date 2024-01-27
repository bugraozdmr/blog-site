using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}