using RestaurantApp.DataAccess.Repositories.Interfaces;
using RestaurantApp.Entity.Entities;

namespace RestaurantApp.DataAccess.Repositories.Implementations;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly List<MenuItem> _menuItems = new();

    public List<MenuItem> GetAll()
    {
        return _menuItems;
    }

    public MenuItem? GetById(int id)
    {
        return _menuItems.FirstOrDefault(x => x.Id == id);
    }

    public void Add(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public void Remove(MenuItem menuItem)
    {
        _menuItems.Remove(menuItem);
    }
}
