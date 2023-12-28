namespace person;

public class User : Person
{
    public string DOB { get; set; }
    public string UserId { get; set; }
    /*| US-user | 12-month | 23-year | 001-number |*/
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Taluka { get; set; }
    public string Village { get; set; }
    public string Region { get; set; }
    public string Address { get; set; }
    public string Panchayat { get; set; }
    public string PostOffice { get; set; }
    public int PinCode { get; set; }

    public User() : this("Omkar", "Ware", "Omkarware003", "Omkarware@123", "omkarware003@gmail.com", "9561466648", "06/10/2001", "US1223001", "Maharashtra", "Beed", "Beed", "Beed", "Beed", "Urban", "Ganesh Nagar", "Beed", "Beed", 431122) { }
    public User(string FirstName, string LastName, string Username, string Password, string EmailId, string PhoneNumber, string DOB, string UserId, string State, string city, string District, string Taluka, string Village, string Region, string Address, string Panchayat, string PostOffice, int PinCode) :
    base(FirstName, LastName, Username, Password, EmailId, PhoneNumber)
    {
        this.DOB = DOB;
        this.UserId = UserId;
        this.State = State;
        this.City = city;
        this.District = District;
        this.Taluka = Taluka;
        this.Village = Village;
        this.Region = Region;
        this.Address = Address;
        this.Panchayat = Panchayat;
        this.PostOffice = PostOffice;
        this.PinCode = PinCode;
    }

    public override string ToString()
    {
        return (base.ToString() + "\nUserId: " + this.UserId + "\nState: " + this.State + "\nCity: " + this.City + "\nDistrict: " + this.District + "\nTaluka: " + this.Taluka + "\nVillage: " + this.Village + "\nRegion: " + this.Region + "\nAddress: " + this.Address + "\nPanchayat: " + this.Panchayat + "\nPost Office: " + this.PostOffice + "\nPin Code: " + this.PinCode + "\nDate of Birth " + this.DOB);
    }
}