namespace ShoppingCartDomain;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public Money Price { get; }
    public IDiscount? Discount { get; }

    private Product()
    {
        // Required for EF Core
    }

    public Product(Guid id, string name, Money price, IDiscount? discount = null) : this()
    {
        Id = id;
        Name = name;
        Price = price;
        Discount = discount;
    }
}
