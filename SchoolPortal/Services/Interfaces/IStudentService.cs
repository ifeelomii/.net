using model;

namespace services;

public interface IStudentService{
    public List<Student> DisplayAllStudentService();
    public List<Student>? DisplayAllStudentByIdService(int id);
    public bool AddNewStudentService(Student st);
    public bool UpdateStudentService(Student st);
    public bool DeleteStudentByIdService(int delid);
    public bool ValidateStudentService(Student std);
}