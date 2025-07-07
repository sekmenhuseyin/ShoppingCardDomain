namespace ShoppingCartDomain;

public class QuantityBasedDiscount(int required, int payFor) : IDiscount
{
    public Money Apply(Product product, int quantity)
    {
        var discountSets = quantity / required;
        var remaining = quantity % required;
        var totalToPay = discountSets * payFor + remaining;

        return product.Price.Multiply(totalToPay);
    }
}
