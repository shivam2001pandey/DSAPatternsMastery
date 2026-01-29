public interface IPaymentMethod
{
    void Pay(double amount);
}

public class CreditCardPayment : IPaymentMethod
{
    public void Pay(double amount) => Console.WriteLine($"CreditCard charged {amount}");
}

public class PayPalPayment : IPaymentMethod
{
    public void Pay(double amount) => Console.WriteLine($"PayPal charged {amount}");
}

// PaymentProcessor now depends on abstraction
public class PaymentProcessorOCP
{
    private readonly IPaymentMethod _paymentMethod;
    public PaymentProcessorOCP(IPaymentMethod paymentMethod) => _paymentMethod = paymentMethod;
    public void Charge(double amount) => _paymentMethod.Pay(amount);
}

// BAD Code
public class PaymentProcessorBAD
{
    public void Charge(string paymentType, double amount)
    {
        if(paymentType=="Credit Card")
        {
            // Do payment logic here
        }
        else if (paymentType == "payPal")
        {
            // Do payment logic here
        }
        else
        {
            //Error: Invalid payment option
        }
    }
}