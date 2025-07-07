namespace ShoppingCartDomain;

/// <summary>
/// e.g. 10 for 10%
/// </summary>
public class PercentageDiscount(decimal percentage) : IDiscount
{

    public Money Apply(Product product, int quantity)
    {
        var total = product.Price.Multiply(quantity);
        var discount = total.Amount * (percentage / 100);

        return new Money(total.Amount - discount, product.Price.Currency);
    }
}
