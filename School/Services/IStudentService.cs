using model;

namespace services;

public interface IStudentService{
    public List<Student> DisplayAllStudentService();
    public List<Student> DisplayAllStudentByIdService(int id);
    public bool AddNewStudentService();
}