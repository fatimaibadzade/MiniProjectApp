using RestaurantApp.Entity.Entities;

namespace RestaurantApp.DataAccess.Repositories.Interfaces;

public interface IMenuItemRepository
{
    List<MenuItem> GetAll();

    MenuItem? GetById(int id);

    void Add(MenuItem menuItem);

    void Remove(MenuItem menuItem);
}
