// Bad code
public interface IProductActions
{
    void ApplyDiscount();
    void Ship();
}

public class DigitalProductBad : IProductActions
{
    public void ApplyDiscount() { /* ok */ }
    public void Ship() => throw new NotImplementedException(); // forced to implement
}


// Refactored code
public interface IDiscountable { void ApplyDiscount(); }
public interface IShippable { void Ship(string address); }

public class PhysicalProduct : IDiscountable, IShippable
{
    public void ApplyDiscount() { }
    public void Ship(string address) => Console.WriteLine($"Shipped to {address}");
}

public class DigitalProduct : IDiscountable
{
    public void ApplyDiscount() { }
    // no Ship method
}
//Clients should depend on only the methods they need. Keeps implementations clean.
