namespace model;

public class Student{
    public int? StudentId{ get; set; }
    public string? NameFirst{ get; set; }
    public string? NameLast{ get; set; }
    public string? DOB{ get; set; }
    public string? EmailId{ get; set; }

    public Student():this(001,"user","user","2000-01-01","user123@gmail.com"){

    }

    public Student(int id, string fnmae, string lname, string DOB ,string emailid){
        this.StudentId = id;
        this.NameFirst = fnmae;
        this.NameLast = lname;
        this.DOB = DOB;
        this.EmailId = emailid;
    }
}