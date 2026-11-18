# Order Discount Calculator

## 1. Overview

The Order Discount Calculator is a C#/..NET 10 application that calculates discounts based on customer types.

The application currently supports three customer categories:

| Customer Type | Discount |
|---|---:|
| Regular | 5% |
| Premium | 10% |
| VIP | 15% |

For each order, the application calculates:
- Original order amount
- Applicable discount percentage
- Discount amount
- Final payable amount

The solution is designed to be extensible so that additional customer categories and discount strategies can be introduced without modifying the core calculation logic.

## 2. Technologies Used

- C#
- ..NET 10
- Object-Oriented Programming (OOP)
- xUnit for unit testing

## 3. How to Run the Solution

### Prerequisites

- ..NET 10 SDK installed
- Visual Studio 2026 or Visual Studio Code (optional)

### Steps

1. Clone or download the solution.
2. Open the solution file (`.sln`) in Visual Studio, or navigate to the solution directory using a terminal.
3. Restore dependencies:

```bash
dotnet restore
```

4. Build the solution:

```bash
dotnet build
```

5. Run the application:

```bash
dotnet run --project OrderDiscountCalculator
```

6. Execute unit tests:

```bash
dotnet test
```

## 4. Design Approach

The solution follows a modular, object-oriented design with clear separation of responsibilities.

The main components are:

- **Order:** Represents order details such as Order ID, customer name, order amount, and customer type.
- **IDiscountStrategy:** Defines the contract for discount calculation, including the customer type and discount rate.
- **Discount Strategies:** Separate implementations for Regular, Premium, and VIP customers.
- **DiscountStrategyFactory:** Responsible for selecting the appropriate discount strategy based on the customer type.
- **DiscountCalculatorService:** Orchestrates the calculation by retrieving the appropriate strategy and calculating the discount and final payable amount.
- **DiscountResult:** Represents the calculated discount details returned to the caller.

### Calculation Flow

1. The application receives an order.
2. The calculator requests the appropriate strategy from the factory using the customer type.
3. The factory returns the matching discount strategy.
4. The strategy calculates the discount amount using its configured discount rate.
5. The calculator rounds the discount amount to two decimal places.
6. The final payable amount is calculated by subtracting the discount from the original order amount.
7. The result is returned to the caller.

## 5. Design Patterns Used

### Strategy Pattern

The Strategy Pattern encapsulates each discount calculation algorithm in a separate class implementing `IDiscountStrategy`.

For example:
- `RegularDiscountStrategy`
- `PremiumDiscountStrategy`
- `VipDiscountStrategy`

**Benefit:** Each discount calculation is independent and can evolve without affecting other strategies.

### Factory Pattern

The Factory Pattern is implemented through `DiscountStrategyFactory`.

It selects and returns the appropriate discount strategy based on the customer type.

**Benefit:** The calculator does not need to know how individual strategies are created or selected. This keeps strategy selection separate from calculation orchestration.

### SOLID Principles

The implementation follows these principles:

- **Single Responsibility Principle (SRP):** Each class has a clearly defined responsibility.
- **Open/Closed Principle (OCP):** New discount strategies can be added without modifying the calculator's calculation logic.
- **Dependency Inversion Principle (DIP):** The calculator depends on the `IDiscountStrategy` abstraction through the factory rather than concrete strategy implementations.

## 6. Assumptions and Business Rules

1. Every order must have a valid Order ID and customer name.
2. Order amount cannot be negative.
3. Discount rates are represented as decimal values:
   - 5% = `0.05m`
   - 10% = `0.10m`
   - 15% = `0.15m`
4. Discount rates must be between 0% and 100%.
5. Only one customer-based discount is applied per order.
6. Discount amounts are rounded to two decimal places using `MidpointRounding.AwayFromZero`.
7. The final amount is calculated using the rounded discount amount.
8. Unsupported customer types result in a clear exception rather than silently applying a default discount.
9. Monetary calculations use the C# `decimal` type to avoid floating-point precision issues.
10. Currency formatting is handled separately from business calculations. The application can use the `en-IN` culture for Indian Rupee formatting.

## 7. Extensibility

The design allows new discount types to be introduced with minimal changes.

For example, to support a Student discount:

1. Create a `StudentDiscountStrategy` implementing `IDiscountStrategy`.
2. Define its customer type and discount rate.
3. Register the new strategy with the factory.

The existing `DiscountCalculatorService` does not need to be modified.

This demonstrates the Open/Closed Principle and makes the solution easier to maintain and extend.

## 8. Testing

Unit tests should validate:

- Correct discount calculation for Regular, Premium, and VIP customers.
- Correct discount percentage reporting.
- Correct final payable amount.
- Decimal precision and rounding behavior.
- Unsupported customer types.
- Invalid order amounts.
- Duplicate strategy registration.
- Zero-value orders.
- Extensibility with additional strategies.

Run all tests using:

```bash
dotnet test
```

## 9. Future Enhancements

Potential enhancements include:

- Support for coupon-based and promotional discounts.
- Combining multiple discount strategies.
- Configuration-driven discount rates.
- Dependency injection using the .NET built-in DI container.
- Logging and centralized exception handling.
- API exposure through ASP.NET Core.
- Integration with a database or external pricing service.

## 10. Conclusion

The solution uses Strategy and Factory patterns to provide a flexible and maintainable discount calculation mechanism.

By separating discount calculation, strategy selection, and order processing, the implementation supports future business requirements while keeping the core calculation logic stable.