using Banking;
using Notification;
using Taxation;

// TaxOperation proxyIncomeTax = new TaxOperation(TaxServices.IncomeTax);
// TaxOperation proxySalesTax = new TaxOperation(TaxServices.SalesTax);
// TaxOperation proxyGSTTax = new TaxOperation(TaxServices.GSTTax);
// TaxOperation proxyServiceTax = new TaxOperation(TaxServices.ServiceTax);

// TaxOperation proxyTax = null;
// proxyTax += proxyIncomeTax;
// proxyTax += proxySalesTax;
// proxyTax += proxyGSTTax;
// proxyTax += proxyServiceTax;
// proxyTax(25000);

// NotificationOperation notificationEmail = new NotificationOperation(NotificationServices.SendEmail);
// NotificationOperation notificationSMS = new NotificationOperation(NotificationServices.SendSMS);
// NotificationOperation notificationWAM = new NotificationOperation(NotificationServices.SendWhatsAppMsg);
// NotificationOperation notification = null;

// notification += notificationEmail;
// notification += notificationSMS;
// notification += notificationWAM;
// notification("Omkar");

Account acc = new Account();
acc.CalTax += TaxServices.IncomeTax;
// acc.CalTax += TaxServices.SalesTax;
// acc.CalTax += TaxServices.GSTTax;
// acc.CalTax += TaxServices.ServiceTax;

acc.Notify += NotificationServices.SendEmail;
// acc.Notify += NotificationServices.SendSMS;
// acc.Notify += NotificationServices.SendWhatsAppMsg;
acc.Balance = 60000;
Console.WriteLine(acc.Balance);
acc.Deposit(140000);
acc.Deposit(200000);
acc.Withdraw(100000);
acc.Withdraw(100000);
acc.Withdraw(140000);
acc.Withdraw(40000);
Console.WriteLine(acc.Balance);