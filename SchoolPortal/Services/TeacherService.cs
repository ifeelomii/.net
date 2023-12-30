using model;
using dao;
namespace services;

public class TeacherService:ITeacherService{
    public TeacherDao db = new TeacherDao();
    public bool ValidateTeacherService(Teacher u){
        bool flag = false;
        flag = db.ValidateTeacherDao(u);
        return flag;
    }

    public List<Teacher> DisplayAllTeacherService(){
        List<Teacher> lst = new List<Teacher>();
        lst = db.DisplayAllTeacherDao();
        return lst;
    }
    public bool AddTeacherService(Teacher u) {
        bool flag = false;
        flag = db.AddNewTeacherDao(u);
        return flag;
    }

    public bool UpdateTeacherByIdService(Teacher usr)
    {
        bool flag = false;
        flag = db.UpdateTeacherByIdDao(usr);
        return flag;
    }

    public bool DeleteTeacherByIdService(string un)
    {
        bool flag = false;
        flag = db.DeleteTeacherByIdDao(un);
        return flag;
    }
}