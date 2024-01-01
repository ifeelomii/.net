using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using model;
using School.Models;
using services;
using System.Collections.Generic;

namespace controllers;

public class StudentController : Controller
{
    static Teacher? t1=null;
    static Student? s1=null;
    private readonly IStudentService _StudentService;

    public StudentController(IStudentService StudentService)
    {
        this._StudentService = StudentService;
    }

    [HttpGet]
    public IActionResult DisplayAll()
    {
        List<Student>? lst = new List<Student>();
        lst = _StudentService.DisplayAllStudentService();
        this.ViewData["students"] = lst;
        return View();
    }
    [HttpPost]
    public IActionResult DisplayAll(int searchId=0)
    {
        List<Student>? lst = new List<Student>();
        List<Student>? list = new List<Student>();
        list = _StudentService.DisplayAllStudentService();
        lst = list;
        if(searchId !=0 ){
            // var students = from s in lst where s.StudentId == searchId select s;
            lst = list.FindAll((e)=>e.StudentId==searchId);
        }
        this.ViewData["students"] = lst;
        return View();
    }

    [HttpGet]
    public IActionResult AddNewStudent()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddNewStudent(int id, string fname, string lname, string dob ,string emailid)
    {
        bool flag;
        Student st = new Student(id,fname,lname,dob,emailid);
        flag = _StudentService.AddNewStudentService(st);
        if(flag){
            s1 =  st;
            this.ViewData["msg"] = "User Registered Successfully";
            return View();
        }
        else{
            this.ViewData["msg"] = "User Registration Failed";
            return View();
        }
    }
    [HttpGet]
    public IActionResult UpdateStudent()
    {
        return View();
    }
    [HttpPost]
    public IActionResult UpdateStudent(int id, string fname, string lname, string dob ,string emailid)
    {
        bool flag;
        Student st = new Student(id,fname,lname,dob,emailid);
        flag = _StudentService.UpdateStudentService(st);
        if(flag){
            s1 =  st;
            this.ViewData["addnewstudents"] = "Updation Successfull";
            return View();
        }
        else{
            this.ViewData["addnewstudents"] = "User Updation Failed";
            return View();
        }
    }

    [HttpGet]
    public IActionResult DeleteStudent(Student std)
    {
        this.ViewData["id"] = std;
        return View();
    }
    [HttpPost]
    public IActionResult DeleteStudent(int delid)
    {
        bool flag = false;
        flag = _StudentService.DeleteStudentByIdService(delid);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string uname, string dob)
    {
        bool flag = false;
        Student tech = new Student
        {
          NameFirst = uname,
          DOB = dob
        };
        flag = _StudentService.ValidateStudentService(tech);
        if (flag) {
            s1 = tech;
            return this.RedirectToAction("DisplayAll");
        }
        else {
            this.ViewData["msg"] = "User Login Failed ! Invalid Credentials?";
            return View();
        }
    }
}
