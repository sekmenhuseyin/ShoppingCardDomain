namespace ShoppingCartTests;

public class ProductTests
{
    [Fact]
    public void Product_ShouldHaveCorrectPrice_WhenNoDiscount()
    {
        var price = new Money(60, "USD");
        var product = new Product(Guid.NewGuid(), "Mug", price);

        var total = product.Price.Multiply(2);

        total.Amount.Should().Be(120);
    }
}