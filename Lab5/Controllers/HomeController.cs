using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Labs;

namespace WebApp.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Lab1(string? input)
    {
        if (input == null)
        {
            TempData["input"] = "'4'";
            TempData["result"] = "Execute task to get result";
            return View();
        }
     
        TempData["input"] = input;
        TempData["result"] = $"Result is {new Lab1().Main(input)}" ;
        return View();
    }

    public IActionResult Lab2(string? input)
    {
        if (input == null)
        {
            TempData["input"] = "'6'";
            TempData["result"] = "Execute task to get result";
            return View();
        }

        TempData["input"] = input;
        TempData["result"] = $"Result is {new Lab2().Main(input)}";
        return View();
    }

    public IActionResult Lab3(string? input)
    {
        if (input == null)
        {
            TempData["input"] = "'5 0 1 0 0 1 1 0 1 0 0 0 1 0 0 0 0 0 0 0 0 1 0 0 0 0 3 5'";
            TempData["result"] = "Execute task to get result";
            return View();
        }

        TempData["input"] = input;
        TempData["result"] = $"Result is {new Lab3().Main(input)}";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

