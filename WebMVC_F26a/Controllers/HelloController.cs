using Microsoft.AspNetCore.Mvc;

namespace WebMVC_F26a.Controllers
{
    public class HelloController : Controller
    {
        // GET: HelloController
        public ActionResult Index()
        {
            return View();
        }

    }
}
