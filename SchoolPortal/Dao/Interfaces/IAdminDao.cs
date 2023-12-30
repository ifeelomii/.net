namespace dao;
using model;
public interface IAdminDao
{
    public bool ValidateAdminDao(Admin u);
    public bool AddNewAdminDao(Admin user);
    
    public bool UpdateAdminByIdDao(Admin user);
    public bool DeleteAdminByIdDao(string un);
    
}