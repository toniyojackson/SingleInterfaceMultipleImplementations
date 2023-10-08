namespace SingleInterfaceMultipleImplementations.PaymentService;

public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer payment of {amount}");
    }
}