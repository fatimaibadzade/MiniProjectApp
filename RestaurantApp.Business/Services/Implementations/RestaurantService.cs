using RestaurantApp.Business.Exceptions;
using RestaurantApp.Business.Services.Interfaces;
using RestaurantApp.DataAccess.Repositories.Implementations;
using RestaurantApp.DataAccess.Repositories.Interfaces;
using RestaurantApp.Entity.Entities;
using RestaurantApp.Entity.Enums;

namespace RestaurantApp.Business.Services.Implementations;

public class RestaurantService : IRestaurantService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IOrderRepository _orderRepository;

    private int _nextMenuItemId = 1;
    private int _nextOrderId = 1;

    public RestaurantService()
    {
        _menuItemRepository = new MenuItemRepository();
        _orderRepository = new OrderRepository();
    }

    public List<MenuItem> MenuItems
    {
        get
        {
            return _menuItemRepository.GetAll();
        }
    }

    public List<Order> Orders
    {
        get
        {
            return _orderRepository.GetAll();
        }
    }

    public void AddMenuItem(
        string name,
        decimal price,
        Category category)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name bos ola bilmez.");
        }

        if (price <= 0)
        {
            throw new ArgumentException(
                "Price 0-dan boyuk olmalidir.");
        }

        bool exists = MenuItems.Any(x =>
            x.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase));

        if (exists)
        {
            throw new DuplicateMenuItemException(
                "Bu adda MenuItem artiq movcuddur.");
        }

        MenuItem menuItem = new MenuItem
        {
            Id = _nextMenuItemId++,
            Name = name,
            Price = price,
            Category = category
        };

        _menuItemRepository.Add(menuItem);
    }

    public void RemoveMenuItem(int id)
    {
        MenuItem? menuItem =
            _menuItemRepository.GetById(id);

        if (menuItem == null)
        {
            throw new MenuItemNotFoundException(
                "MenuItem tapilmadi.");
        }

        _menuItemRepository.Remove(menuItem);
    }

    public void EditMenuItem(
        int id,
        string name,
        decimal price)
    {
        MenuItem? menuItem =
            _menuItemRepository.GetById(id);

        if (menuItem == null)
        {
            throw new MenuItemNotFoundException(
                "MenuItem tapilmadi.");
        }

        bool duplicate = MenuItems.Any(x =>
            x.Id != id &&
            x.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase));

        if (duplicate)
        {
            throw new DuplicateMenuItemException(
                "Bu adda basqa MenuItem artiq movcuddur.");
        }

        if (price <= 0)
        {
            throw new ArgumentException(
                "Price 0-dan boyuk olmalidir.");
        }

        menuItem.Name = name;
        menuItem.Price = price;
    }

    public List<MenuItem> GetMenuItemsByCategory(
        Category category)
    {
        return MenuItems
            .Where(x => x.Category == category)
            .ToList();
    }

    public List<MenuItem> GetMenuItemsByPriceInterval(
        decimal minPrice,
        decimal maxPrice)
    {
        return MenuItems
            .Where(x =>
                x.Price >= minPrice &&
                x.Price <= maxPrice)
            .ToList();
    }

    public List<MenuItem> SearchMenuItems(string search)
    {
        return MenuItems
            .Where(x =>
                x.Name.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void AddOrder(Dictionary<int, int> menuItems)
    {
        if (menuItems == null || menuItems.Count == 0)
        {
            throw new ArgumentException(
                "Sifaris bos ola bilmez.");
        }

        List<OrderItem> orderItems = new();

        foreach (var item in menuItems)
        {
            MenuItem? menuItem =
                _menuItemRepository.GetById(item.Key);

            if (menuItem == null)
            {
                throw new MenuItemNotFoundException(
                    $"Id: {item.Key} olan MenuItem tapilmadi.");
            }

            if (item.Value <= 0)
            {
                throw new ArgumentException(
                    "Count 0-dan boyuk olmalidir.");
            }

            orderItems.Add(new OrderItem
            {
                MenuItem = menuItem,
                Count = item.Value
            });
        }

        decimal totalAmount = orderItems.Sum(x =>
            x.MenuItem.Price * x.Count);

        Order order = new Order
        {
            Id = _nextOrderId++,
            OrderItems = orderItems,
            TotalAmount = totalAmount,
            Date = DateTime.Now
        };

        _orderRepository.Add(order);
    }

    public void RemoveOrder(int orderId)
    {
        Order? order =
            _orderRepository.GetById(orderId);

        if (order == null)
        {
            throw new OrderNotFoundException(
                "Order tapilmadi.");
        }

        _orderRepository.Remove(order);
    }

    public List<Order> GetOrdersByDatesInterval(
        DateTime startDate,
        DateTime endDate)
    {
        startDate = startDate.Date;
        endDate = endDate.Date;

        return Orders
            .Where(x =>
                x.Date.Date >= startDate &&
                x.Date.Date <= endDate)
            .ToList();
    }

    public List<Order> GetOrderByDate(DateTime date)
    {
        return Orders
            .Where(x => x.Date.Date == date.Date)
            .ToList();
    }

    public List<Order> GetOrdersByPriceInterval(
        decimal minPrice,
        decimal maxPrice)
    {
        return Orders
            .Where(x =>
                x.TotalAmount >= minPrice &&
                x.TotalAmount <= maxPrice)
            .ToList();
    }

    public Order GetOrderByNo(int orderId)
    {
        Order? order =
            _orderRepository.GetById(orderId);

        if (order == null)
        {
            throw new OrderNotFoundException(
                "Order tapilmadi.");
        }

        return order;
    }
}
