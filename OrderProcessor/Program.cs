using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SingleInterfaceMultipleImplementations.PaymentService;
using System.Linq;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    // Get all the registered implementations of the IPaymentProcessor interface
   var processors = services.GetServices<IPaymentProcessor>().ToList();

   // To run all the implementations
   foreach (var processor in processors)
   {
       processor.ProcessPayment(100);
   }
   
   // To run only particular Payment type
   var creditCardProcessor = processors.FirstOrDefault(x => x.GetType() == typeof(CreditCardPaymentProcessor));
   creditCardProcessor?.ProcessPayment(200);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
            services.AddScoped<IPaymentProcessor, PayPalPaymentProcessor>();
            services.AddScoped<IPaymentProcessor, BankTransferPaymentProcessor>();
        });
}