using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _ScriptsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}