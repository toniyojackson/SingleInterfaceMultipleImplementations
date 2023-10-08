namespace SingleInterfaceMultipleImplementations.PaymentService;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}