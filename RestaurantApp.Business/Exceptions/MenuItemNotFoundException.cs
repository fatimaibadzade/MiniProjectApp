namespace RestaurantApp.Business.Exceptions;

public class MenuItemNotFoundException : Exception
{
    public MenuItemNotFoundException(string message)
        : base(message)
    {
    }
}
