using model;
using dao;
namespace services;

public class TeacherService:ITeacherService{
    public bool ValidateTeacherService(Teacher u){
        bool flag = false;
        flag = TeacherDao.ValidateTeacherDao(u);
        return flag;
    }

    public List<Teacher> DisplayAllTeacherService(){
        List<Teacher> lst = new List<Teacher>();
        lst = TeacherDao.DisplayAllTeacherDao();
        return lst;
    }
    public bool AddTeacherService(Teacher u) {
        bool flag = false;
        flag = TeacherDao.AddNewTeacherDao(u);
        return flag;
    }

    public bool UpdateTeacherByIdService(Teacher usr)
    {
        bool flag = false;
        flag = TeacherDao.UpdateTeacherByIdDao(usr);
        return flag;
    }

    public bool DeleteTeacherByIdService(string un)
    {
        bool flag = false;
        flag = TeacherDao.DeleteTeacherByIdDao(un);
        return flag;
    }
}