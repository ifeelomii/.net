namespace dao;

using dbtest;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

public class Dao : Idao
{
    public bool DisplayStudentDao()
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT * FROM newstudent";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmd.Connection = conn;
                cmd.CommandText = query;
                #pragma warning disable CS8604 // Possible null reference argument.
                int studentId = int.Parse(reader["studentID"].ToString());
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nameFirst = reader["namefirst"].ToString();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string nameLast = reader["namelast"].ToString();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string Dob = reader["dob"].ToString();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string emailId = reader["email"].ToString();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("\nId: " + studentId + " First Name: " + nameFirst + " Last Name: " + nameLast + " Date of Birth " + Dob + " Email: " + emailId);
            }
            return true;
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return false;
        }
    }
    public bool AddNewStudentDao()
    {
        // Student st = new Student(63,"Omkar","Ware","2001-10-06","omkarware003");
        Student st = new Student();
        Console.WriteLine("Enter Student Id");
        st.StudentId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student First Name");
        st.NameFirst= Console.ReadLine();
        Console.WriteLine("Enter Student Last Name");
        st.NameLast= Console.ReadLine();
        Console.WriteLine("Enter Student Email ID");
        st.EmailId= Console.ReadLine();

        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "INSERT INTO newstudent(studentID,namefirst,namelast,dob,email) VALUES('"+st.StudentId+"','"+st.NameFirst+"','"+st.NameLast+"','"+st.DOB+"','"+st.EmailId+"')";
        MySqlCommand cmd = new MySqlCommand(query, conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteStudentDao()
    {
        Student st = new Student();
        Console.WriteLine("Enter Student Id To Delete");
        st.StudentId = int.Parse(Console.ReadLine());

        MySqlConnection conn = new MySqlConnection();

        try
        {
            conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
            string query = "DELETE FROM newstudent WHERE studentID="+st.StudentId;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool UpdateStudentDao()
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";

        Student st = new Student();
        Console.WriteLine("Enter Student Id");
        st.StudentId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student First Name");
        st.NameFirst= Console.ReadLine();
        Console.WriteLine("Enter Student Last Name");
        st.NameLast= Console.ReadLine();
        Console.WriteLine("Enter Student Email ID");
        st.EmailId= Console.ReadLine();
        
        string query = "UPDATE newstudent SET studentID='"+st.StudentId+ "',namefirst='"+ st.NameFirst+"',namelast='"+ st.NameLast+"',dob='"+st.DOB+"',email='"+st.EmailId+"' WHERE studentID='"+st.StudentId+"'";
        MySqlCommand cmd = new MySqlCommand(query, conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}