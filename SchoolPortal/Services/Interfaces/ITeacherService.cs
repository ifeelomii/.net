using model;

namespace services;

public interface ITeacherService{
    public bool ValidateTeacherService(Teacher u);
    public bool AddTeacherService(Teacher u);
    public List<Teacher> DisplayAllTeacherService();
    public bool UpdateTeacherByIdService(Teacher usr);
    public bool DeleteTeacherByIdService(string un);
}