using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using model;
using services;

namespace controllers;

public class TeacherController : Controller
{
    private static int trial = 2;
    private static string? msg = null;
    static Teacher? t1=null;
    static List<Teacher>? tl1=null;
    private readonly ITeacherService _TeacherService;

    public TeacherController(ITeacherService TeacherService)
    {
        this._TeacherService = TeacherService;
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
        if (access) {
            bool flag = false;
            Teacher user = new Teacher {
            UserName = uname,
            Password = pwd
            };
            flag = _TeacherService.ValidateTeacherService(user);
            if (flag) {
                t1 = user;
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
        this.ViewData["list"] = t1;
        this.ViewData["login"] = TempData["display-login"];

        return View();
    }

    [HttpGet]
    public IActionResult DisplayAll()
    {
        List<Teacher> lst = new List<Teacher>();
        lst = _TeacherService.DisplayAllTeacherService();
        this.ViewData["teachers"] = lst;
        return View();
    }
    [HttpPost]
    public IActionResult DisplayAll(int searchId=0)
    {
        List<Teacher> lst = new List<Teacher>();
        List<Teacher> list = new List<Teacher>();
        list = _TeacherService.DisplayAllTeacherService();
        lst = list;
        // TempData["display-login"] = list;
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
    public IActionResult Register(int userid, string fname, string lname,string uname, string pwd)
    {
        bool flag = false;
        Teacher usr = new Teacher(userid,fname,lname,uname,pwd);
        flag = _TeacherService.AddTeacherService(usr);
        if(flag){
            t1 =  usr;
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
        this.ViewData["register"] = t1;
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
        Teacher usr = new Teacher(userid,fname,lname,uname,pwd);
        flag = _TeacherService.UpdateTeacherByIdService(usr);
        if(flag){
            t1 =  usr;
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
        flag = _TeacherService.DeleteTeacherByIdService(delun);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }
}