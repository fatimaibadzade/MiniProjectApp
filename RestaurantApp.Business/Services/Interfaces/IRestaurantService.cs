using RestaurantApp.Entity.Entities;
using RestaurantApp.Entity.Enums;

namespace RestaurantApp.Business.Services.Interfaces;

public interface IRestaurantService
{
    List<MenuItem> MenuItems { get; }

    List<Order> Orders { get; }

    void AddMenuItem(string name, decimal price, Category category);

    void RemoveMenuItem(int id);

    void EditMenuItem(int id, string name, decimal price);

    List<MenuItem> GetMenuItemsByCategory(Category category);

    List<MenuItem> GetMenuItemsByPriceInterval(
        decimal minPrice,
        decimal maxPrice);

    List<MenuItem> SearchMenuItems(string search);

    void AddOrder(Dictionary<int, int> menuItems);

    void RemoveOrder(int orderId);

    List<Order> GetOrdersByDatesInterval(
        DateTime startDate,
        DateTime endDate);

    List<Order> GetOrderByDate(DateTime date);

    List<Order> GetOrdersByPriceInterval(
        decimal minPrice,
        decimal maxPrice);

    Order GetOrderByNo(int orderId);
}
