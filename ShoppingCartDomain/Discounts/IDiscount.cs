namespace ShoppingCartDomain;

public interface IDiscount
{
    Money Apply(Product product, int quantity);
}
