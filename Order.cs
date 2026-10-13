namespace Assignment08.Section02
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order(int id, string customerName, decimal price, int quantity)
        {
            Id = id;
            CustomerName = customerName;
            Price = price;
            Quantity = quantity;
        }
    }
}