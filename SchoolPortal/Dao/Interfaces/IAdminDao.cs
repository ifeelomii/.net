namespace dao;
using model;
public interface IAdminDao
{
    public static abstract bool ValidateAdminDao(Admin u);
    public static abstract bool AddNewAdminDao(Admin user);
    public static abstract bool UpdateAdminByIdDao(Admin user);
    public static abstract bool DeleteAdminByIdDao(string un);
    
}