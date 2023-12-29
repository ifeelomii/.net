namespace dao;
using model;
public interface IDBConnectionUser
{
    public bool ValidateUserDao(User u);
    public bool AddNewUserDao(User user);
    public bool UpdateUserByIdDao(User user);
    public bool DeleteUserByIdDao(int id);
    
}