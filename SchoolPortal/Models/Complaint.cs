namespace model;

public class Complaint{
    public int? ComplaintId{ get; set; }
    public string? NameFirst{ get; set; }
    public string? NameLast{ get; set; }
    public string? EmailId{ get; set; }
    public string? Description{ get; set; }

    public Complaint():this(001,"user","user","user123@gmail.com","NA"){

    }

    public Complaint(int id, string fnmae, string lname, string emailid ,string desc){
        this.ComplaintId = id;
        this.NameFirst = fnmae;
        this.NameLast = lname;
        this.EmailId = emailid;
        this.Description = desc;
    }
}