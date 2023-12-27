using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using model;
using School.Models;
using services;
using System.Collections.Generic;

namespace StudentControllers;

public class StudentController : Controller
{
    public List<Student> lst = new List<Student>();
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        StudentService std = new StudentService();
        lst = std.DisplayAllStudentService();
        this.ViewData["students"] = lst;
        return View();
    }
    public IActionResult Index2()
    {
        Console.WriteLine("Enter Id to be searched");
        int id = int.Parse(Console.ReadLine());
        StudentService std = new StudentService();
        lst = std.DisplayAllStudentByIdService(id);
        this.ViewData["studentsbyid"] = lst;
        return View();
    }
    public IActionResult Index3()
    {
        bool status;
        StudentService std = new StudentService();
        status = std.AddNewStudentService();
        this.ViewData["studentsbyid"] = status;
        return View();
    }
}
