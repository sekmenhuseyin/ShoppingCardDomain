# 🛒 Shopping Cart Domain

A simple Shopping Cart domain implementation in C# using **Domain-Driven Design (DDD)** principles.  
It supports core e-commerce cart features including item totals, quantities, and multiple discount types.

---

## ✨ Features

- Add products with or without discounts
- Calculate total item count and price
- Apply different types of discounts:
    - ✅ Percentage-based (e.g. 10% off)
    - ✅ Fixed-amount (e.g. $10 off)
    - ✅ Quantity-based (e.g. 3-for-2)

---

## 📦 Project Structure

```
ShoppingCart/
├── Entities/
│   ├── Cart.cs
│   ├── CartItem.cs
│   └── Product.cs
├── ValueObjects/
│   └── Money.cs
├── Discounts/
│   ├── IDiscount.cs
│   ├── PercentageDiscount.cs
│   ├── FixedAmountDiscount.cs
│   └── QuantityBasedDiscount.cs
└── Tests/
    ├── CartTests.cs
    ├── DiscountTests.cs
    └── ProductTests.cs
```

---

## 🧪 Unit Tests

Written using [xUnit](https://xunit.net/) and [FluentAssertions](https://fluentassertions.com/).

Run tests with:

```bash
  dotnet test
```

Example test cases:
- Cart total with mixed discounts
- Quantity merging in cart
- Discount logic validation

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- (Optional) Rider, Visual Studio, or VS Code

### Run Locally

```bash
  git clone https://github.com/sekmenhuseyin/ShoppingCardDomain.git
  cd ShoppingCardDomain
  dotnet build
```

To run tests:

```bash
  dotnet test
```

---

## 📌 Example Usage

```csharp
var apple = new Product(Guid.NewGuid(), "Apple", new Money(1.0m, "USD"), new QuantityBasedDiscount(3, 2));
var cart = new Cart();
cart.AddItem(apple, 3);

Console.WriteLine($"Total Items: {cart.TotalItemCount}"); // 3
Console.WriteLine($"Total Price: {cart.GetTotalPrice().Amount}"); // $2
```

---

## 🧱 Principles Used

- Domain-Driven Design (DDD)
- Value Objects (`Money`)
- Aggregate Root (`Cart`)
- Domain Logic Encapsulation (`CartItem`, `Discounts`)

---

## 📄 License

This project is licensed under the MIT License.

---

## 🙋‍♂️ Author

**Hüseyin Sekmenoğlu**  
https://huseyin.sekmen.dev/
