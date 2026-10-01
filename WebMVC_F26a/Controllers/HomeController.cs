using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC_F26a.Models;

namespace WebMVC_F26a.Controllers;

// Handles general site pages. Each action returns an HTTP response, often by rendering a view.
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // ASP.NET Core provides registered services such as this logger through constructor injection.
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // View() uses the MVC convention to find Views/Home/Index.cshtml.
    public IActionResult Index()
    {
        return View();
    }

    // The action name selects Views/Home/Privacy.cshtml by convention.
    public IActionResult Privacy()
    {
        return View();
    }

    // Build a model for the error page; avoid caching this request-specific response.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
