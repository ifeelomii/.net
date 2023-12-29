using model;
using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Collections.Generic;

namespace dao;

public class DBConnectionUser:IDBConnectionUser {
    public bool ValidateUserDao(User u) {
    MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString = "server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
    string query = "SELECT FirstName, Password FROM user_data";
    MySqlCommand cmd = new MySqlCommand(query, conn);
    try {
        conn.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        bool flag = false;
        while (reader.Read())
        {
            User usr = new User();
            usr.FirstName = reader["FirstName"].ToString();
            usr.Password = reader["Password"].ToString();
            if (usr.FirstName == u.FirstName && usr.Password == u.Password) {
                Console.WriteLine("\n Valid User");
                flag = true;
            }
            // Console.WriteLine("\n User Validation");
        }
        return flag;
        } catch (System.Exception e) {
        Console.WriteLine("Exception Found "+e.Message);
        return false;
        }
    }

    public bool AddNewUserDao(User usr)
    {        
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "INSERT INTO user_data(UserId,FirstName,LastName,Password) VALUES('"+usr.UserId+"','"+usr.FirstName+"','"+usr.LastName+"','"+usr.Password+"')";
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

    public bool UpdateUserByIdDao(User usr)
    {
        User user = new User();
        user.UserId = usr.UserId;
        user.FirstName = usr.FirstName;
        user.LastName = usr.LastName;
        user.Password = usr.Password;
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
        string query = "UPDATE user_data SET UserId='"+user.UserId+ "',FirstName='"+ user.FirstName+"',LastName='"+ user.LastName +"',Password='"+ user.Password +"'WHERE UserId='"+user.UserId+"'";
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

    public bool DeleteUserByIdDao(int id)
    {
        User user = new User();
        user.UserId = id;
        MySqlConnection conn = new MySqlConnection();
        try
        {
            conn.ConnectionString =" server=192.168.10.150; port=3306; user=dac4; password=welcome; database=dac4";
            string query = "DELETE FROM user_data WHERE UserId='"+user.UserId+"'";
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


}
