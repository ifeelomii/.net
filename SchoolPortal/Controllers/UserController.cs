using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using model;
using services;

namespace School.Controllers;

public class UserController : Controller
{
    // public static int count = 10;
    static int trial = 2;
    public static string? msg = null;
    static User? u1=null;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
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
    public IActionResult Login(string fname, string pwd)
    {
        bool access = true;
        if (trial == 0)
            access = false;
        if(access){
            bool flag = false;
            User user = new User();
            UserService us = new UserService();
            user.FirstName = fname;
            user.Password = pwd;
            flag = us.ValidateUserService(user);
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
        this.ViewData["login"] = u1;

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
        User usr = new User();
        // usr.UserId = count;
        usr.UserId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.Password = pwd;
        UserService uss = new UserService();
        flag = uss.AddUserService(usr);
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
    public IActionResult UpdateUser()
    {
        return View();
    }
    [HttpPost]
    public IActionResult UpdateUser(int userid, string fname, string lname, string pwd)
    {
        bool flag = false;
        User usr = new User();
        usr.UserId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.Password = pwd;
        UserService uss = new UserService();
        flag = uss.UpdateUserByIdService(usr);
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
    public IActionResult DeleteUser()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteUser(int delid)
    {
        bool flag = false;
        UserService uss = new UserService();
        flag = uss.DeleteUserByIdService(delid);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }

}