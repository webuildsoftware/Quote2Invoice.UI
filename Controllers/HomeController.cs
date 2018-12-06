using Microsoft.AspNetCore.Mvc;
using Quote2Invoice.UI.Shared;
using Quote2Invoice.UI.Shared.WebApiCaller;

namespace Quote2Invoie.UI.Controllers
{
  public class HomeController : Controller
  {
    public HomeController(IWebApiCaller webApiCaller, ICookieHelper cookieHelper)
    {
    }

    public ViewResult Error(GlobalErrorModel webApiErrorModel)
    {
      return View(webApiErrorModel);
    }
  }
}
