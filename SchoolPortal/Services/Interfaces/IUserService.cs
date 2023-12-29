using model;

namespace services;

public interface IUserService{
    public bool ValidateUserService(User u);
    public bool AddUserService(User u);
    public bool UpdateUserByIdService(User usr);
    public bool DeleteUserByIdService(int id);
}