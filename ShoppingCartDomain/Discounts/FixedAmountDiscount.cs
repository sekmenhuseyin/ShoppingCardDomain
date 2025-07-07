namespace ShoppingCartDomain;

public class FixedAmountDiscount(decimal amount) : IDiscount
{
    public Money Apply(Product product, int quantity)
    {
        var total = product.Price.Multiply(quantity);
        var discounted = total.Amount - amount;

        return new Money(Math.Max(0, discounted), product.Price.Currency);
    }
}
