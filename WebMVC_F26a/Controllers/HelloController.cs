using Microsoft.AspNetCore.Mvc;

namespace WebMVC_F26a.Controllers
{
    public class HelloController : Controller
    {
        // GET: HelloController
    public IActionResult Index()
    {
        //return Content("Hello World");
        return View();
    }

    public IActionResult MN()
    {
        return View("MN");
    }

    public IActionResult Minnesota()
    {
        return View("MN");
    }

    public IActionResult WI()
    {
        return View("WI");
    }

    }
}
