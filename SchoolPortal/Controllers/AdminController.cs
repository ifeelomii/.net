using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using model;
using services;

namespace controllers;

public class AdminController : Controller
{
    // public static int count = 10;
    static int trial = 2;
    private static string? msg = null;
    static Admin? u1=null;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
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
            Admin ad = new Admin();
            AdminService aser = new AdminService();
            ad.UserName = uname;
            ad.Password = pwd;
            flag = aser.ValidateAdminService(ad);
            if (flag) {
                u1 = ad;
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
        Admin usr = new Admin();
        // usr.UserId = count;
        usr.AdminId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.Password = pwd;
        AdminService uss = new AdminService();
        flag = uss.AddAdminService(usr);
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
    public IActionResult UpdateAdmin()
    {
        return View();
    }
    [HttpPost]
    public IActionResult UpdateAdmin(int userid, string fname, string lname,string uname, string pwd)
    {
        bool flag = false;
        Admin usr = new Admin();
        usr.AdminId = userid;
        usr.FirstName = fname;
        usr.LastName = lname;
        usr.UserName = uname;
        usr.Password = pwd;
        AdminService uss = new AdminService();
        flag = uss.UpdateAdminByIdService(usr);
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
    public IActionResult DeleteAdmin()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteAdmin(string delun)
    {
        bool flag = false;
        AdminService uss = new AdminService();
        flag = uss.DeleteAdminByIdService(delun);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }

}