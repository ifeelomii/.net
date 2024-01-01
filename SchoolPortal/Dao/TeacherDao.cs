using model;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;

namespace dao;

public class TeacherDao:ITeacherDao {
    
    public static bool ValidateTeacherDao(Teacher u) 
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT Username, Password FROM newteacher";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try 
        {
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            while (reader.Read())
            {
                Teacher usr = new Teacher();
                usr.UserName = reader["Username"].ToString();
                usr.Password = reader["Password"].ToString();
                if (usr.UserName == u.UserName && usr.Password == u.Password) {
                    Console.WriteLine("\n Valid User");
                    flag = true;
                }
            // Console.WriteLine("\n User Validation");
            }
            return flag;
        } 
        catch (System.Exception e) {
            Console.WriteLine("Exception Found "+e.Message);
            return false;
        }
    }

    public static bool AddNewTeacherDao(Teacher usr)
    {        
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "INSERT INTO newteacher(TeacherId,FirstName,LastName,Username,Password) VALUES('"+usr.TeacherId+"','"+usr.FirstName+"','"+usr.LastName+"','"+usr.UserName+"','"+usr.Password+"')";
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

    public static bool UpdateTeacherByIdDao(Teacher usr)
    {
        Teacher user = new Teacher();
        user.TeacherId = usr.TeacherId;
        user.FirstName = usr.FirstName;
        user.LastName = usr.LastName;
        user.UserName = usr.UserName;
        user.Password = usr.Password;
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "UPDATE newteacher SET UserId='"+user.TeacherId+ "',FirstName='"+ user.FirstName+"',LastName='"+ user.LastName +"',Username='"+ user.UserName +"',Password='"+ user.Password +"'WHERE TeacherId='"+user.TeacherId+"'";
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

    public static bool DeleteTeacherByIdDao(string un)
    { 
        Teacher user = new Teacher();
        user.UserName = un;
        MySqlConnection conn = new MySqlConnection();
        try
        {
            conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
            string query = "DELETE FROM newteacher WHERE Username='"+user.UserName+"'";
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

    public static List<Teacher>? DisplayAllTeacherDao()
    {
        List<Teacher> lst = new List<Teacher>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString ="server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT * FROM newteacher";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Teacher tech = new Teacher();
                cmd.Connection = conn;
                cmd.CommandText = query;
#pragma warning disable CS8604 // Possible null reference argument.
                tech.TeacherId = int.Parse(reader["TeacherID"].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                tech.FirstName = reader["FirstName"].ToString();
                tech.LastName = reader["LastName"].ToString();
                tech.UserName = reader["UserName"].ToString();
                lst.Add(tech);
                // Console.WriteLine("\nId: " + st.StudentId + " First Name: " + st.NameFirst + " Last Name: " + st.NameLast + " Date of Birth " + st.DOB + " Email: " + st.EmailId);
            }
            Console.WriteLine("\n Data Fetched From DataBase");
            return lst; 
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
