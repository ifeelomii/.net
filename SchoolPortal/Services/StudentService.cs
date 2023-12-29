using model;
using dao;
namespace services;
using System.Collections.Generic;
public class StudentService : IStudentService
{
    public StudentDao db = new StudentDao();   
    public List<Student> DisplayAllStudentService()
    {
        List<Student> lst = new List<Student>();
        lst = db.DisplayAllStudentDao();
        return lst;
    }

    public List<Student>? DisplayAllStudentByIdService(int id)
    {
        int Id = id;
        List<Student> allStudents=db.DisplayStudentByIdDao(id);    
        // List<Student> student=allStudents.FindAll((s)=> s.StudentId ==Id);
        return allStudents ;
    }

    public bool AddNewStudentService(Student st)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = db.AddNewStudentDao(st);
        return flag;
    }
    public bool UpdateStudentService(Student st)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = db.UpdateUserByIdDao(st);
        return flag;
    }

    public bool DeleteStudentByIdService(int delid)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = db.DeleteUserByIdDao(delid);
        return flag;
    }
}