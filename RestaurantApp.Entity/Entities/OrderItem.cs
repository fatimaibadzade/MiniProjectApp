namespace RestaurantApp.Entity.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int MenuItemId { get; set; }

    public MenuItem MenuItem { get; set; } = null!;

    public int Count { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;
}
