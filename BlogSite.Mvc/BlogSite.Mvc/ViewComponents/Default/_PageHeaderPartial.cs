using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.Default;

public class _PageHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}