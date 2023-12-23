namespace Banking;
public class Account    
{
    public event TaxOperation CalTax;
    public event NotificationOperation Notify;
    public float Balance{get;set;}
    public void Deposit(float amount){
        this.Balance=Balance+amount;
        if(Balance>=250000){
            float currBalance = Balance - (0.1f * Balance);
            CalTax(0.1f * Balance);
            Console.WriteLine("Remaining Balance = " + currBalance);
        }
    }
    public void Withdraw(float amount){
        this.Balance=Balance-amount;
        if(Balance<=25000){
            Notify("Omkar");
        }
    }
}
