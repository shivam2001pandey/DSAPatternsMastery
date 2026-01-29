// Bad: All responsibilities in one class (violates SRP, DIP, OCP, etc.)
public class OrderServiceBad
{
    public void PlaceOrder(string customerId, string productId, int qty, string paymentType)
    {
        // 1. Validate
        if (qty <= 0) throw new Exception("Invalid qty");

        // 2. Check stock (hard-coded DB call simulation)
        Console.WriteLine("Checking stock in SQL DB");
        bool inStock = true;
        if (!inStock) throw new Exception("Out of stock");

        // 3. Calculate price + discount
        double price = 100.0 * qty;
        if (customerId == "VIP") price *= 0.8; // hard-coded rule

        // 4. Process payment (if/else)
        if (paymentType == "CreditCard")
        {
            Console.WriteLine("Charging via Credit Card gateway");
        }
        else if (paymentType == "PayPal")
        {
            Console.WriteLine("Charging via PayPal");
        }
        else
        {
            throw new Exception("Unsupported payment");
        }

        // 5. Save order
        Console.WriteLine("Saving order to SQL DB");

        // 6. Send email
        Console.WriteLine("Sending Email via SMTP");

        // 7. Done
        Console.WriteLine("Order placed (bad)");
    }
}