using model;
using dao;

namespace services;

public class AdminService:IAdminService{
    public bool ValidateAdminService(Admin u){
        bool flag = false;
        AdminDao db = new AdminDao();
        flag = db.ValidateAdminDao(u);
        return flag;
    }
    public bool AddAdminService(Admin u) {
        bool flag = false;
        AdminDao db = new AdminDao();
        flag = db.AddNewAdminDao(u);
        return flag;
    }

    public bool UpdateAdminByIdService(Admin usr)
    {
        bool flag = false;
        AdminDao db = new AdminDao();
        flag = db.UpdateAdminByIdDao(usr);
        return flag;
    }

    public bool DeleteAdminByIdService(string un)
    {
        bool flag = false;
        AdminDao db = new AdminDao();
        flag = db.DeleteAdminByIdDao(un);
        return flag;
    }

    public List<Admin> DisplayAllAdminService()
    {
        AdminDao db = new AdminDao();
        List<Admin> allAdmins=db.DisplayAllAdminDao();    
        // List<Student> student=allStudents.FindAll((s)=> s.StudentId ==Id);
        return allAdmins ;
    }
}