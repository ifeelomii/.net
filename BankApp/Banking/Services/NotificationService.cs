namespace Notification;

public static class NotificationServices{
    public static void SendEmail(string name){
        Console.WriteLine("Email is sent to "+name);
    }
    public static void SendSMS(string name){
        Console.WriteLine("SMS is sent to "+name);
    }
    public static void SendWhatsAppMsg(string name){
        Console.WriteLine("WhatsApp message is sent to "+name);
    }

}