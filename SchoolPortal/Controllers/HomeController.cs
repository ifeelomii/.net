using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using model;
using School.Models;

namespace controllers;

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

    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Contact(string fname, string lname, string emailid, string desc)
    {
        List<Complaint> complaint = new List<Complaint>();
        Complaint c = new Complaint();
        c.NameFirst = fname;
        c.NameLast = lname;
        c.EmailId = emailid;
        c.Description = desc;
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
