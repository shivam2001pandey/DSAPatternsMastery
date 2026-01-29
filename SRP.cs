// Validator
public class OrderValidator
{
    public void Validate(string productId, int qty)
    {
        if (qty <= 0) throw new ArgumentException("qty");
    }
}

// Repository (persistence)
public class OrderRepository
{
    public void SaveOrder(Order order)
    {
        // DB code
        Console.WriteLine("Order saved to DB");
    }
}

// Payment processing (single responsibility)
public class PaymentProcessor
{
    public void Charge(string paymentType, double amount)
    {
        // still simplistic; single responsibility: payment
        Console.WriteLine($"Charged {amount} via {paymentType}");
    }
}

// Notification
public class NotificationService
{
    public void SendOrderConfirmation(string customerId, string orderId)
    {
        Console.WriteLine($"Email sent to {customerId} for order {orderId}");
    }
}

// Facade OrderService coordinates (small responsibility)
public class OrderServiceSRP
{
    private readonly OrderValidator _validator = new();
    private readonly OrderRepository _repo = new();
    private readonly PaymentProcessor _payment = new();
    private readonly NotificationService _notify = new();

    public void PlaceOrder(string customerId, string productId, int qty, string paymentType)
    {
        _validator.Validate(productId, qty);

        // Business logic left minimal here
        double amount = 100 * qty;

        _payment.Charge(paymentType, amount);

        var order = new Order { Id = Guid.NewGuid().ToString(), CustomerId = customerId };
        _repo.SaveOrder(order);

        _notify.SendOrderConfirmation(customerId, order.Id);
    }
}
