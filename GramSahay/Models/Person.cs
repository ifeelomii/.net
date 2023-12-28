namespace person;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string EmailId { get; set; }
    public string PhoneNumber { get; set; }


    public Person() : this("Omkar", "Ware", "Omkarware003", "Omkarware@123", "omkarware003@gmail.com", "9561466648") { }
    public Person(string FirstName, string LastName, string Username, string Password, string EmailId, string PhoneNumber)
    {

        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Username = Username;
        this.Password = Password;
        this.PhoneNumber = PhoneNumber;
        this.EmailId = EmailId;

    }

    public override string ToString()
    {
        return ("\nName: " + this.FirstName + " " + this.LastName + "\nUser Name: " + this.Username + "\nPassword: " + this.Password + "\nPhone Number: " + this.PhoneNumber + "\nEmail Id: " + this.EmailId);
    }
}