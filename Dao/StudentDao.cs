using model;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;

namespace dao;

public class StudentDao:IStudentDao{
    public List<Student>? DisplayAllStudentDao()
    {
        List<Student> lst = new List<Student>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString ="server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT * FROM newstudent";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student st = new Student();
                cmd.Connection = conn;
                cmd.CommandText = query;
                st.StudentId = int.Parse(reader["studentID"].ToString());
                st.NameFirst = reader["namefirst"].ToString();
                st.NameLast = reader["namelast"].ToString();
                st.DOB = reader["dob"].ToString();
                st.EmailId = reader["email"].ToString();
                lst.Add(st);
                // Console.WriteLine("\nId: " + st.StudentId + " First Name: " + st.NameFirst + " Last Name: " + st.NameLast + " Date of Birth " + st.DOB + " Email: " + st.EmailId);
            }
            Console.WriteLine("\n Data Fetched From DataBase");
            return lst; 
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public List<Student>? DisplayStudentByIdDao(int id)
    {
        int searchID = id;
        List<Student> lst = new List<Student>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString ="server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT * FROM newstudent WHERE studentID="+searchID;
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student st = new Student();
                cmd.Connection = conn;
                cmd.CommandText = query;
                st.StudentId = int.Parse(reader["studentID"].ToString());
                st.NameFirst = reader["namefirst"].ToString();
                st.NameLast = reader["namelast"].ToString();
                st.DOB = reader["dob"].ToString();
                st.EmailId = reader["email"].ToString();
                lst.Add(st);
                // Console.WriteLine("\nId: " + st.StudentId + " First Name: " + st.NameFirst + " Last Name: " + st.NameLast + " Date of Birth " + st.DOB + " Email: " + st.EmailId);
            }
            return lst; 
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return null;
        }finally{
            Console.WriteLine("\n Connection Closed !");
            conn.Clone();
        }
    }
    public bool AddNewStudentDao(Student st)
    {
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

    public bool UpdateStudentByIdDao(Student std)
    {
        Student st = new Student();
        st.StudentId = std.StudentId;
        st.NameFirst = std.NameFirst;
        st.NameLast = std.NameLast;
        st.DOB = std.DOB;
        st.EmailId = std.EmailId;
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "UPDATE newstudent SET studentID='"+st.StudentId+ "',namefirst='"+ st.NameFirst+"',namelast='"+ st.NameLast +"',dob='"+ st.DOB +"',email='"+ st.EmailId +"'WHERE studentID='"+st.StudentId+"'";
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

    public bool DeleteStudentByIdDao(int id)
    {
        Student st = new Student();
        st.StudentId = id;
        MySqlConnection conn = new MySqlConnection();
        try
        {
            conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
            string query = "DELETE FROM newstudent WHERE studentID='"+st.StudentId+"'";
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

    public bool ValidateStudentDao(Student std)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT namefirst,dob FROM newstudent";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try 
        {
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            while (reader.Read())
            {
                Student usr = new Student();
                usr.NameFirst = reader["namefirst"].ToString();
                usr.DOB = reader["dob"].ToString();
                Console.WriteLine(usr.DOB);
                if (usr.NameFirst == std.NameFirst && usr.DOB == std.DOB) {
                    Console.WriteLine("\n Valid User");
                    flag = true;
                }
            }
            return flag;
        } 
        catch (System.Exception e) {
            Console.WriteLine("Exception Found "+e.Message);
            return false;
        }
    }
}