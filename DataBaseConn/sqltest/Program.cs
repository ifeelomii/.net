using System.Drawing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using dbtest;
using dao;
using System.Xml.Serialization;
using services;


StudentServices sts = new StudentServices();
int ch = 0;
do {
    Console.WriteLine("\nEnter 1: To Display All Students");
    Console.WriteLine("Enter 2: To Add New Student");
    Console.WriteLine("Enter 3: To Update Existing Student By ID");
    Console.WriteLine("Enter 4: To Delete Existing Student By ID");
    Console.WriteLine("Enter 5: To Exist");
    Console.WriteLine("Enter Your Choice");
    #pragma warning disable CS8604 // Possible null reference argument.
    ch = int.Parse(Console.ReadLine());
    #pragma warning restore CS8604 // Possible null reference argument.

    switch (ch)
    {
        case 1:
            bool flag = sts.DisplayStudent();
            if(flag){
                Console.WriteLine("Display Operation Successfull");
            }else
            {
                Console.WriteLine("Unexpected Error Occured: Display Operation Unuccessfull\n");
            }
            break;
        case 2:
            flag = sts.AddStudent();
            if(flag){
                Console.WriteLine("Addition Operation Successfull\n");
            }else
            {
                Console.WriteLine("Unexpected Error Occured: Addition Operation Unuccessfull\n");
            }
            break;
        case 3:
            flag = sts.UpdateStudent();
            if(flag){
                Console.WriteLine("Updation Operation Successfull");
            }else
            {
                Console.WriteLine("Unexpected Error Occured: Updation Operation Unuccessfull\n");
            }
            break;
        case 4:
            flag=sts.DeleteStudent();
            if(flag){
                Console.WriteLine("Deletion Operation Successfull");
            }else
            {
                Console.WriteLine("Unexpected Error Occured: Deletion Operation Unuccessfull\n");
            }
            break;
        case 5:
            MySqlConnection conn = new MySqlConnection();
            conn.Close();
            Console.WriteLine("Database Connection Closed");
            Console.WriteLine("Application Ended");
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Application Ended");
            break;
    }    

} while (ch!=5);