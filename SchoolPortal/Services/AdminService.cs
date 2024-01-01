using model;
using dao;

namespace services;

public class AdminService:IAdminService{
    public bool ValidateAdminService(Admin u){
        bool flag = false;
        flag = AdminDao.ValidateAdminDao(u);
        return flag;
    }
    public bool AddAdminService(Admin u) {
        bool flag = false;
        flag = AdminDao.AddNewAdminDao(u);
        return flag;
    }

    public bool UpdateAdminByIdService(Admin usr)
    {
        bool flag = false;
        flag = AdminDao.UpdateAdminByIdDao(usr);
        return flag;
    }

    public bool DeleteAdminByIdService(string un)
    {
        bool flag = false;
        flag = AdminDao.DeleteAdminByIdDao(un);
        return flag;
    }

    public List<Admin>? DisplayAllAdminService()
    {
        List<Admin>? allAdmins=AdminDao.DisplayAllAdminDao();    
        // List<Student> student=allStudents.FindAll((s)=> s.StudentId ==Id);
        return allAdmins ;
    }
}