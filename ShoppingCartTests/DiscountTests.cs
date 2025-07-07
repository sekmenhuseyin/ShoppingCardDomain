namespace ShoppingCartTests;

public class DiscountTests
{
    [Fact]
    public void PercentageDiscount_ShouldApplyCorrectly()
    {
        var price = new Money(100, "USD");
        var product = new Product(Guid.NewGuid(), "Shirt", price, new PercentageDiscount(10));

        var discounted = product.Discount!.Apply(product, 1);

        discounted.Amount.Should().Be(90);
    }

    [Fact]
    public void FixedAmountDiscount_ShouldApplyCorrectly()
    {
        var price = new Money(100, "USD");
        var product = new Product(Guid.NewGuid(), "Pants", price, new FixedAmountDiscount(30));

        var discounted = product.Discount!.Apply(product, 1);

        discounted.Amount.Should().Be(70);
    }

    [Fact]
    public void QuantityBasedDiscount_3For2_ShouldApplyCorrectly()
    {
        var price = new Money(10, "USD");
        var product = new Product(Guid.NewGuid(), "Apple", price, new QuantityBasedDiscount(3, 2));

        var discounted = product.Discount!.Apply(product, 3);

        discounted.Amount.Should().Be(20); // Pay for 2, get 3
    }

    [Fact]
    public void QuantityBasedDiscount_6Items_ShouldApplyCorrectly()
    {
        var price = new Money(10, "USD");
        var product = new Product(Guid.NewGuid(), "Apple", price, new QuantityBasedDiscount(3, 2));

        var discounted = product.Discount!.Apply(product, 6);

        discounted.Amount.Should().Be(40); // 2 sets of 3 -> pay for 4
    }
}