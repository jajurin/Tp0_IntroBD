using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP0_IntroBD.Models;

namespace TP0_IntroBD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
