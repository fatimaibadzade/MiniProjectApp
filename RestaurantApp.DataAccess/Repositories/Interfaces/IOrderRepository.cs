using RestaurantApp.Entity.Entities;

namespace RestaurantApp.DataAccess.Repositories.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAll();

    Order? GetById(int id);

    void Add(Order order);

    void Remove(Order order);
}
