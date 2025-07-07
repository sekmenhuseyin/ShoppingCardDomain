namespace ShoppingCartTests;

public class CartTests
{
    [Fact]
    public void GetTotalPriceOfItemsWithDiscountsTests()
    {
        var price50 = new Money(50, "USD");
        var price30 = new Money(30, "USD");
        var price20 = new Money(20, "USD");

        var apple = new Product(Guid.NewGuid(), "Apple", price50, new PercentageDiscount(10));
        var banana = new Product(Guid.NewGuid(), "Banana", price30, new FixedAmountDiscount(5));
        var orange = new Product(Guid.NewGuid(), "Orange", price20, new QuantityBasedDiscount(3, 2));

        var cart = new Cart();
        cart.AddItem(apple, 2);     // 10% off
        cart.AddItem(banana, 1);    // $5 off
        cart.AddItem(orange, 3);    // 3 for 2

        Assert.Equal(6, cart.TotalItemCount);
        Assert.Equal(155m, cart.GetTotalPrice().Amount); // (2 * 45) + (25 * 1) + (20 * 2) = 90 + 25 + 40 = 155
    }

    [Fact]
    public void Cart_ShouldAddItemsCorrectly()
    {
        var cart = new Cart();
        var product = new Product(Guid.NewGuid(), "Book", new Money(50, "USD"));

        cart.AddItem(product, 2);

        cart.Items.Should().HaveCount(1);
        cart.TotalItemCount.Should().Be(2);
    }

    [Fact]
    public void Cart_ShouldMergeQuantities()
    {
        var cart = new Cart();
        var product = new Product(Guid.NewGuid(), "Book", new Money(50, "USD"));

        cart.AddItem(product, 1);
        cart.AddItem(product, 3);

        cart.Items.Should().HaveCount(1);
        cart.TotalItemCount.Should().Be(4);
    }

    [Fact]
    public void Cart_ShouldCalculateTotalWithoutDiscounts()
    {
        var cart = new Cart();
        var product = new Product(Guid.NewGuid(), "Book", new Money(50, "USD"));

        cart.AddItem(product, 2);

        var total = cart.GetTotalPrice();
        total.Amount.Should().Be(100);
        total.Currency.Should().Be("USD");
    }

    [Fact]
    public void Cart_ShouldCalculateTotalWithMixedDiscounts()
    {
        var cart = new Cart();

        var shirt = new Product(Guid.NewGuid(), "Shirt", new Money(100, "USD"), new PercentageDiscount(10)); // 90
        var hat = new Product(Guid.NewGuid(), "Hat", new Money(40, "USD"), new FixedAmountDiscount(10));      // 30
        var socks = new Product(Guid.NewGuid(), "Socks", new Money(10, "USD"), new QuantityBasedDiscount(3, 2)); // 3 items = 20

        cart.AddItem(shirt, 1);
        cart.AddItem(hat, 1);
        cart.AddItem(socks, 3);

        var total = cart.GetTotalPrice();
        total.Amount.Should().Be(90 + 30 + 20); // 140
    }
}