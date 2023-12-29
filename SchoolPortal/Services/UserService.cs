using model;
using dao;
namespace services;

public class UserService:IUserService{
    public bool ValidateUserService(User u){
        bool flag = false;
        DBConnectionUser db = new DBConnectionUser();
        flag = db.ValidateUserDao(u);
        return flag;
    }
    public bool AddUserService(User u) {
        bool flag = false;
        DBConnectionUser db = new DBConnectionUser();
        flag = db.AddNewUserDao(u);
        return flag;
    }

    public bool UpdateUserByIdService(User usr)
    {
        bool flag = false;
        DBConnectionUser db = new DBConnectionUser();
        flag = db.UpdateUserByIdDao(usr);
        return flag;
    }

    public bool DeleteUserByIdService(int id)
    {
        bool flag = false;
        DBConnectionUser db = new DBConnectionUser();
        flag = db.DeleteUserByIdDao(id);
        return flag;
    }
}