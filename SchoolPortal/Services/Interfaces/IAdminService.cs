using model;

namespace services;

public interface IAdminService{
    public bool ValidateAdminService(Admin std);
    public bool AddAdminService(Admin st);
    public List<Admin> DisplayAllAdminService();
    public bool UpdateAdminByIdService(Admin st);
    public bool DeleteAdminByIdService(string un);
}