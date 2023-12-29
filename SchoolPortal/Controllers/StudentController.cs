using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using model;
using School.Models;
using services;
using System.Collections.Generic;

namespace StudentControllers;

public class StudentController : Controller
{
    static Student? s1=null;
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult DisplayAll()
    {
        List<Student> lst = new List<Student>();
        StudentService std = new StudentService();
        lst = std.DisplayAllStudentService();
        this.ViewData["students"] = lst;
        return View();
    }


    [HttpGet]
    public IActionResult DisplayById()
    {
        System.Console.WriteLine("Display by Id");
        List<Student> lst = new List<Student>();
        this.ViewData["studentsbyid"] = lst;
        return View();
    }

    [HttpPost]
    public IActionResult DisplayById(int searchId)
    {        
        List<Student>? lst = new List<Student>();
        StudentService std = new StudentService();
        lst = std.DisplayAllStudentByIdService(searchId);
        this.ViewData["studentsbyid"] = lst;
        return View();
        // return this.RedirectToAction("");
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
        Student st = new Student();
        st.StudentId = id;
        st.NameFirst = fname;
        st.NameLast = lname;
        st.DOB = dob;
        st.EmailId = emailid;
        StudentService std = new StudentService();
        flag = std.AddNewStudentService(st);
        if(flag){
            // count++;
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
        Student st = new Student();
        st.StudentId = id;
        st.NameFirst = fname;
        st.NameLast = lname;
        st.DOB = dob;
        st.EmailId = emailid;
        StudentService std = new StudentService();
        flag = std.UpdateStudentService(st);
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
    public IActionResult DeleteStudent()
    {
        return View();
    }
    [HttpPost]
    public IActionResult DeleteStudent(int delid)
    {
        bool flag = false;
        StudentService ss = new StudentService();
        flag = ss.DeleteStudentByIdService(delid);
        if(flag){
            this.ViewData["msg"] = "User Deleted Successfully";
            return View();
        }else{
            this.ViewData["msg"] = "User Deletion Failed";
            return View();
        }
        
    }
}
