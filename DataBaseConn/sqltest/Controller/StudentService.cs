using dao;
using dbtest;

namespace services;

public class StudentServices : IStudentServices
{
    Dao dao = new Dao();
    public bool DisplayStudent()
    {
        bool flag=dao.DisplayStudentDao();
        if(flag){
            return true;
        }
        return false;
    }

    public bool AddStudent()
    {
        bool flag = dao.AddNewStudentDao();
        if(flag){
            return true;
        }
        return false;
    }

    public bool DeleteStudent()
    {
        bool flag=dao.DeleteStudentDao();
        if(flag){
            return true;
        }
        return false;
    }

    public bool UpdateStudent()
    {
        bool flag=dao.UpdateStudentDao();
        if(flag){
            return true;
        }
        return false;
    }
}