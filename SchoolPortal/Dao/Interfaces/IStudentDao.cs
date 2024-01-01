namespace dao;
using model;

public interface IStudentDao{
    public static abstract List<Student> DisplayAllStudentDao();
    public static abstract List<Student> DisplayStudentByIdDao(int id);
    public static abstract bool AddNewStudentDao(Student st);
    public static abstract bool UpdateStudentByIdDao(Student std);
    public static abstract bool DeleteStudentByIdDao(int id);
    public static abstract bool ValidateStudentDao(Student std);
}