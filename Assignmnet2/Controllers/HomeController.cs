using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers;

public class HomeController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }
    
    public IActionResult Tasks()
    {
        return View();
    }

}