using System;

namespace Assignment08.Section02
{
    // Part 1: User-Defined Delegate
    public delegate decimal PriceCalculator(Order order);

    public class OrderService
    {
        // Part 5: Event Declaration using Action<Order>
        public event Action<Order> OrderProcessed;

        // Part 1 Method: Using user-defined delegate
        public decimal CalculateOrderPrice(Order order, PriceCalculator calculator)
        {
            return calculator?.Invoke(order) ?? 0m;
        }

        // Part 2 & Bonus Challenge Method: Using Func<Order, decimal> for pricing strategy
        public decimal CalculateOrderPrice(Order order, Func<Order, decimal> calculator)
        {
            return calculator?.Invoke(order) ?? 0m;
        }

        // Part 3 Method: Validating order using Predicate<Order>
        public bool ValidateOrder(Order order, Predicate<Order> validationRule)
        {
            return validationRule?.Invoke(order) ?? false;
        }

        // Part 4 Method: Processing action using Action<Order>
        public void ExecuteAction(Order order, Action<Order> action)
        {
            action?.Invoke(order);
        }

        // Part 5 Method: Processing order and raising the event
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"[OrderService] Processing Order #{order.Id}...");
            
            // Raise the event to notify all subscribed handlers
            OrderProcessed?.Invoke(order);
        }
    }
}