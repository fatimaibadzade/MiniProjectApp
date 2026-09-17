namespace RestaurantApp.Business.Exceptions;

public class DuplicateMenuItemException : Exception
{
    public DuplicateMenuItemException(string message)
        : base(message)
    {
    }
}
