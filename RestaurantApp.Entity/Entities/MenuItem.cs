namespace RestaurantApp.Entity.Entities;

public class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public Enums.Category Category { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();
}
