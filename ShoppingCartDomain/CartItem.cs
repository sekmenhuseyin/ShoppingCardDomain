namespace ShoppingCartDomain;

public class CartItem
{
    public Product Product { get; }
    public int Quantity { get; private set; }

    private CartItem()
    {
        // Required for EF Core
    }

    public CartItem(Product product, int quantity) : this()
    {
        Product = product;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int amount) => Quantity += amount;

    public Money GetTotal()
    {
        return Product.Discount == null
            ? Product.Price.Multiply(Quantity) :
            Product.Discount.Apply(Product, Quantity);
    }
}
