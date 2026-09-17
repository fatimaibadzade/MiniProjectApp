namespace RestaurantApp.Entity.Entities;

public class Order
{
    public int Id { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();

    public decimal TotalAmount { get; set; }

    public DateTime Date { get; set; }
}
