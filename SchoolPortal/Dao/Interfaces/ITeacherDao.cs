namespace dao;
using model;
public interface ITeacherDao
{
    public static abstract bool ValidateTeacherDao(Teacher u);
    public static abstract bool AddNewTeacherDao(Teacher user);
    public static abstract List<Teacher> DisplayAllTeacherDao();
    public static abstract bool UpdateTeacherByIdDao(Teacher user);
    public static abstract bool DeleteTeacherByIdDao(string un);
    
}