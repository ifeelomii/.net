using model;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;

namespace dao;

public class AdminDao:IAdminDao {

    public List<Admin>? DisplayAllAdminDao()
    {
        List<Admin> lst = new List<Admin>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString ="server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT * FROM newadmin";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Admin ad = new Admin();
                cmd.Connection = conn;
                cmd.CommandText = query;
                ad.AdminId = int.Parse(reader["adminId"].ToString());
                ad.FirstName = reader["firstname"].ToString();
                ad.LastName = reader["lastname"].ToString();
                ad.UserName = reader["username"].ToString();
                ad.Password = reader["password"].ToString();
                lst.Add(ad);
                // Console.WriteLine("\nId: " + st.AdminId + " First Name: " + st.NameFirst + " Last Name: " + st.NameLast + " Date of Birth " + st.DOB + " Email: " + st.EmailId);
            }
            Console.WriteLine("\n Data Fetched From DataBase");
            return lst; 
        }catch (System.Exception e){
            Console.WriteLine(e.Message);
            return null;
        }finally{
            conn.Close();
        }
    }
    
    public bool ValidateAdminDao(Admin u) 
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "SELECT Username, Password FROM newAdmin";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try 
        {
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            while (reader.Read())
            {
                Admin ad = new Admin();
                ad.UserName = reader["username"].ToString();
                ad.Password = reader["password"].ToString();
                if (ad.UserName == u.UserName && ad.Password == u.Password) {
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
        }finally{
            conn.Close();
        }
    }

    public bool AddNewAdminDao(Admin usr)
    {        
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "INSERT INTO newadmin(adminId,firstname,lastname,username,password) VALUES('"+usr.AdminId+"','"+usr.FirstName+"','"+usr.LastName+"','"+usr.UserName+"','"+usr.Password+"')";
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
        }finally{
            conn.Close();
        }
    }

    public bool UpdateAdminByIdDao(Admin usr)
    {
        Admin user = new Admin();
        user.AdminId = usr.AdminId;
        user.FirstName = usr.FirstName;
        user.LastName = usr.LastName;
        user.UserName = usr.UserName;
        user.Password = usr.Password;
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "UPDATE newadmin SET adminId='"+user.AdminId+ "',firstname='"+ user.FirstName+"',lastname='"+ user.LastName +"',username='"+ user.UserName +"',password='"+ user.Password +"'WHERE adminId='"+user.AdminId+"'";
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
        }finally{
            conn.Close();
        }
    }

    public bool DeleteAdminByIdDao(string un)
    {
        Admin user = new Admin();
        user.UserName = un;
        MySqlConnection conn = new MySqlConnection();
        try
        {
            conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
            string query = "DELETE FROM newadmin WHERE username='"+user.UserName+"'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }finally{
            conn.Close();
        }
    }
}
