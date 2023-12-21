namespace person;

public class GramSevak : Person
{
    public string GramSevakId { get; set; }
    /*| GS-Gram sevak | 12-month | 23-year | 001-number |*/
    public string State { get; set; }
    public string District { get; set; }
    public string Taluka { get; set; }
    public string Village { get; set; }
    public int Status { get; set; }

    public GramSevak() : this("Omkar", "Ware", "Omkarware003", "Omkarware@123", "omkarware003@gmail.com", "9561466648", "GS1223001", "Maharashtra", "Beed", "Beed", "Beed", 0) { }
    public GramSevak(string FirstName, string LastName, string Username, string Password, string EmailId, string PhoneNumber, string GramSevakId, string State, string District, string Taluka, string Village, int Status) :
    base(FirstName, LastName, Username, Password, EmailId, PhoneNumber)
    {
        this.GramSevakId = GramSevakId;
        this.State = State;
        this.District = District;
        this.Taluka = Taluka;
        this.Village = Village;
        this.Status = Status;
    }

    public override string ToString()
    {
        return (base.ToString() + "\nGramsevak Id: " + this.GramSevakId + "\nState: " + this.State + "\nDistrict: " + this.District + "\nTaluka: " + this.Taluka + "\nVillage: " + this.Village + "\nStatus: " + this.Status);
    }

}