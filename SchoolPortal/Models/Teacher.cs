namespace model;

public class Teacher{
    public int? TeacherId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName{ get; set; }
    public string? Password { get; set; }

     public Teacher():this(001,"user","user","user","user123"){

    }

    public Teacher(int id, string fnmae, string lname, string uname ,string pwd){
        this.TeacherId = id;
        this.FirstName = fnmae;
        this.LastName = lname;
        this.UserName = uname;
        this.Password = pwd;
    }
}