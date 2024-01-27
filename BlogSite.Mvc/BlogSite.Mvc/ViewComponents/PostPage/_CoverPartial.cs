using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.ViewComponents.PostPage;

public class _CoverPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}