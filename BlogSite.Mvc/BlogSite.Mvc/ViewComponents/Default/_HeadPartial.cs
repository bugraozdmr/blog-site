using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _HeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}