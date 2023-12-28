namespace person;
/*admin_id VARCHAR(30) PRIMARY KEY,*/
public class Admin : Person
{
    public string AdminId { get; set; }

    public Admin() : this("Omkar", "Ware", "Omkarware003", "Omkarware@123", "omkarware003@gmail.com", "9561466648", "AD1223001") { }
    public Admin(string FirstName, string LastName, string Username, string Password, string EmailId, string PhoneNumber, string AdminId)
    {

        this.AdminId = AdminId;

    }

    public override string ToString()
    {
        return (base.ToString() + "\nAdmin Id: " + this.AdminId);
    }
}