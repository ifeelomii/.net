using model;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;

namespace dao;

public class DBConnection{
    public List<Student> DisplayAllStudentDao()
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
                Console.WriteLine("\nId: " + st.StudentId + " First Name: " + st.NameFirst + " Last Name: " + st.NameLast + " Date of Birth " + st.DOB + " Email: " + st.EmailId);
            }
            return lst; 
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public List<Student> DisplayStudentByIdDao(int id)
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
        }
    }
    public bool AddNewStudentDao()
    {
        // Student st = new Student(63,"Omkar","Ware","2001-10-06","omkarware003");
        Student st = new Student();
        

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
}