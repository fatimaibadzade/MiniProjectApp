using RestaurantApp.DataAccess.Repositories.Interfaces;
using RestaurantApp.Entity.Entities;

namespace RestaurantApp.DataAccess.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public List<Order> GetAll()
    {
        return _orders;
    }

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public void Remove(Order order)
    {
        _orders.Remove(order);
    }
}
