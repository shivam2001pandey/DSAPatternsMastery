// BAD Code
public class Discount
{
    public virtual double Apply(double price) => price; // maybe default
}

public class SeasonalDiscount : Discount
{
    public override double Apply(double price) => price * 0.9;
}

public class FreeTrialDiscount : Discount
{
    public override double Apply(double price)
    {
        // Wrongly throws if price > 0
        if (price > 0) throw new InvalidOperationException("Free trial invalid for paid items");
        return 0;
    }
}


// Good code
public interface IPricePolicy
{
    double GetPrice(double basePrice);
}

public class PercentageDiscountPolicy : IPricePolicy
{
    private readonly double _factor;
    public PercentageDiscountPolicy(double factor) => _factor = factor;
    public double GetPrice(double basePrice) => basePrice * _factor;
}

public class FreePolicy : IPricePolicy
{
    public double GetPrice(double basePrice) => 0; // always valid, does not throw
}

