namespace Taxation;

public static class TaxServices{
    public static void IncomeTax(float amount){
        Console.WriteLine("Income Tax Rs. "+amount+" has been debited from your account.");
    }
    public static void SalesTax(float amount){
        Console.WriteLine("Sales Tax Rs. "+amount+" has been debited from your account.");
    }
    public static void GSTTax(float amount){
        Console.WriteLine("GST Rs. "+amount+" has been debited from your account.");
    }
    public static void ServiceTax(float amount){
        Console.WriteLine("Service Tax Rs. "+amount+" has been debited from your account.");
    }
}