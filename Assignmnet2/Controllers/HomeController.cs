using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Assignment2.Data;

namespace Assignment2.Controllers;

public class HomeController(AppUserContext context) : Controller
{
    public AppUserContext Context { get; } = context;

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string password)
    {
        if (email == "hr@example.com" && password == "hr1234")
        {
            TempData["role"] = "HR";
            return RedirectToAction("List","Employee");
        }
        else if(email == "employee@example.com" && password == "emp1234")
        {
            TempData["role"] = "Employee";
            return RedirectToAction("List", "EmpTask");
        }
        TempData["error"] = "Invalid email or password";
        return RedirectToAction("Login");
    }
    public IActionResult Login()
    {
        var error = TempData["error"];
        ViewBag.Error = error;
        return View();
    }
    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }
    

}