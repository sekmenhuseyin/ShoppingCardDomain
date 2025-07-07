namespace ShoppingCartDomain;

public class Cart
{
    private readonly List<CartItem> _items = [];
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public void AddItem(Product product, int quantity = 1)
    {
        var existing = _items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing != null)
        {
            existing.IncreaseQuantity(quantity);
        }
        else
        {
            _items.Add(new CartItem(product, quantity));
        }
    }

    public int TotalItemCount => _items.Sum(i => i.Quantity);

    public Money GetTotalPrice()
    {
        if (_items.Count == 0)
            return Money.Zero("USD");

        var currency = _items[0].Product.Price.Currency;
        var total = Money.Zero(currency);

        return _items.Aggregate(total, (current, item) => current.Add(item.GetTotal()));
    }
}