namespace model;

public class Admin{
    public int? AdminId{ get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string UserName{ get; set; }
    public string Password{ get; set; }

    public Admin():this(00,"user","user","user","user"){}
    public Admin(int id, string fnmae, string lname,string uname,string pwd){
        this.AdminId = id;
        this.FirstName = fnmae;
        this.LastName = lname;
        this.UserName = uname;
        this.Password = pwd;
    }
}