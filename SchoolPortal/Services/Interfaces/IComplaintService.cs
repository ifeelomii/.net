using model;

namespace services;

public interface IComplaintService{
    public bool AddComplaintService(Complaint cmp);
    public List<Complaint> DisplayAllComplaintService();
    public bool UpdateComplaintByIdService(Complaint cmp);
    public bool DeleteComplaintByIdService(string un);
}