namespace dao;
using model;

public interface IStudentDao{
    public List<Student> DisplayAllStudentDao();
    public List<Student> DisplayStudentByIdDao(int id);
    public bool AddNewStudentDao(Student st);
    public bool UpdateStudentByIdDao(Student std);
    public bool DeleteStudentByIdDao(int id);
    public bool ValidateStudentDao(Student std);
}