using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using model;
using services;

namespace controllers;

public class TeacherController : Controller
{
    // public static int count = 10;
    static int trial = 2;
    private static string? msg = null;
    static Teacher? u1=null;
    private readonly ILogger<TeacherController> _logger;

    public TeacherController(ILogger<TeacherController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string uname, string pwd)
    {
        bool access = true;
        if (trial == 0)
            access = false;
        if(access){
            bool flag = false;
            Teacher user = new Teacher();
            TeacherService us = new TeacherService();
            user.UserName = uname;
            user.Password = pwd;
            flag = us.ValidateTeacherService(user);
            if (flag) {
                u1 = user;
                return this.RedirectToAction("ValidLogin");
            }
            else {
                trial--;
                this.ViewData["msg"] = "User Login Failed ! Invalid Credentials?";
                return View();
            }
        }else{
            trial = 2;
            TempData["msg"] = "Login Limit Exceeded !";
            return this.RedirectToAction("Register");
        }
    }
    [HttpGet]
    public IActionResult ValidLogin()
    {
        this.ViewData["list"] = u1;
        this.ViewData["login"] = TempData["display-login"];

        return View();
    }

    [HttpGet]
    public IActionResult DisplayAll()
    {
        List<Teacher> lst = new List<Teacher>();
        TeacherService std = new TeacherService();
        lst = std.DisplayAllTeacherService();
        this.ViewData["teachers"] = lst;
        return View();
    }
    [HttpPost]
    public IActionResult DisplayAll(int searchId=0)
    {
        List<Teacher> lst = new List<Teacher>();
        List<Teacher> list = new List<Teacher>();
        TeacherService std = new TeacherService();
        list = std.DisplayAllTeacherService();
        lst = list;
        TempData["display-login"] = lst;
        if(searchId !=0 ){
            // var students = from s in lst where s.StudentId == searchId select s;
            lst = list.FindAll((e)=>e.TeacherId==searchId);
        }
        this.ViewData["teachers"] = lst;
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        this.ViewData["limit"] = TempData["msg"];
        return View();
    }
    [HttpPost]
    public IActionResult Register(int userid, string fname, string lname, string pwd)
    {
        bool flag = false;
        Teacher usr = new Teacher();
        // usr.UserId = count;
        usr.TeacherId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.Password = pwd;
        TeacherService uss = new TeacherService();
        flag = uss.AddTeacherService(usr);
        if(flag){
            // count++;
            u1 =  usr;
            this.ViewData["msg"] = "User Registered Successfully";
            return View();
        }
        else{
            this.ViewData["msg"] = "User Registration Failed";
            return View();
        }
    }
    [HttpGet]
    public IActionResult ValidRegistration()
    {
        this.ViewData["register"] = u1;
        return View();
    }
    
    [HttpGet]
    public IActionResult UpdateTeacher()
    {
        return View();
    }
    [HttpPost]
    public IActionResult UpdateTeacher(int userid, string fname, string lname,string uname, string pwd)
    {
        bool flag = false;
        Teacher usr = new Teacher();
        usr.TeacherId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.UserName = uname;
        usr.Password = pwd;
        TeacherService uss = new TeacherService();
        flag = uss.UpdateTeacherByIdService(usr);
        if(flag){
            u1 =  usr;
            this.ViewData["msg"] = "Updation Successfull";
            return View();
        }
        else{
            this.ViewData["msg"] = "User Updation Failed";
            return View();
        }
    }
    [HttpGet]
    public IActionResult DeleteTeacher()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteTeacher(string delun)
    {
        bool flag = false;
        TeacherService uss = new TeacherService();
        flag = uss.DeleteTeacherByIdService(delun);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }

}