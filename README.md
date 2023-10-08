# Multiple implementations of the same Interface
This repository have a example of which implementation should be called when we have multiple implementations of the same interface
using .Net dependency injection. 

## Interface
```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
```

## Classes
```csharp
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
    }
}
```
```csharp
public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}");
    }
}
```
```csharp
public class BankTransferPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer payment of {amount}");
    }
}
```
## Dependency Injection
```csharp
services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
services.AddScoped<IPaymentProcessor, PayPalPaymentProcessor>();
services.AddScoped<IPaymentProcessor, BankTransferPaymentProcessor>();
```
## To run all the registered implementations
```csharp
var processors = services.GetServices<IPaymentProcessor>().ToList();

foreach (var processor in processors)
{
   processor.ProcessPayment(100);
}
```
## To run only particular implementation
```csharp
var creditCardProcessor = processors.FirstOrDefault(x => x.GetType() == typeof(CreditCardPaymentProcessor));
creditCardProcessor?.ProcessPayment(200);
```