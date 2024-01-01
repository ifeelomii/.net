using model;
using dao;
namespace services;
using System.Collections.Generic;
public class StudentService : IStudentService
{  
    public List<Student>? DisplayAllStudentService()
    {
        List<Student>? lst = new List<Student>();
        lst = StudentDao.DisplayAllStudentDao();
        return lst;
    }

    public List<Student>? DisplayAllStudentByIdService(int id)
    {
        int Id = id;
        List<Student>? allStudents=StudentDao.DisplayStudentByIdDao(id);    
        // List<Student> student=allStudents.FindAll((s)=> s.StudentId ==Id);
        return allStudents ;
    }

    public bool AddNewStudentService(Student st)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = StudentDao.AddNewStudentDao(st);
        return flag;
    }
    public bool UpdateStudentService(Student st)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = StudentDao.UpdateStudentByIdDao(st);
        return flag;
    }

    public bool DeleteStudentByIdService(int delid)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = StudentDao.DeleteStudentByIdDao(delid);
        return flag;
    }

    public bool ValidateStudentService(Student std)
    {
        bool flag;
        StudentDao db = new StudentDao();
        flag = StudentDao.ValidateStudentDao(std);
        return flag;
    }
}