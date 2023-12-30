namespace dao;
using model;
public interface ITeacherDao
{
    public bool ValidateTeacherDao(Teacher u);
    public bool AddNewTeacherDao(Teacher user);
    public List<Teacher> DisplayAllTeacherDao();
    public bool UpdateTeacherByIdDao(Teacher user);
    public bool DeleteTeacherByIdDao(string un);
    
}