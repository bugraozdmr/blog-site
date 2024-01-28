using BlogSite.Mvc.Dtos.RouteParameters;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Mvc.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index(int pagesize,int pagenumber)
    {
        FromRouteDto dto = new FromRouteDto()
        {
            pagenumber = pagenumber,
            pagesize = pagesize
        };
        
        return View(dto);
    }
}