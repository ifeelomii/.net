using dbtest;

namespace services;

public interface IStudentServices{
    public bool DisplayStudent();
    public bool AddStudent();

    public bool UpdateStudent();
    public bool DeleteStudent();
}