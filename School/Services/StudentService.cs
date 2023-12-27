using model;
using dao;
namespace services;
using System.Collections.Generic;
public class StudentService : IStudentService
{
    public List<Student> lst = new List<Student>();
    public DBConnection db = new DBConnection();   
    public List<Student> DisplayAllStudentService()
    {
        lst = db.DisplayAllStudentDao();
        return lst;
    }

    public List<Student> DisplayAllStudentByIdService(int id)
    {
        int Id = id;
        lst = db.DisplayStudentByIdDao(Id);
        return lst;
    }

    public bool AddNewStudentService()
    {
        bool flag;
        flag = db.AddNewStudentDao();
        return flag;
    }
}