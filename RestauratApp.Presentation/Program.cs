using RestaurantApp.Business.Services.Implementations;
using RestaurantApp.Business.Services.Interfaces;
using RestaurantApp.Entity.Entities;
using RestaurantApp.Entity.Enums;

IRestaurantService service = new RestaurantService();

while (true)
{
    Console.Clear();

    Console.WriteLine("===== RESTAURANT ORDER SYSTEM =====");
    Console.WriteLine();
    Console.WriteLine("1 - Menu uzerinde emeliyyat aparmaq");
    Console.WriteLine("2 - Sifarisler uzerinde emeliyyat aparmaq");
    Console.WriteLine("0 - Sistemden cixmaq");
    Console.WriteLine();

    Console.Write("Secim: ");
    string? choice = Console.ReadLine();

    if (choice == "1")
    {
        MenuOperations(service);
    }
    else if (choice == "2")
    {
        OrderOperations(service);
    }
    else if (choice == "0")
    {
        Console.WriteLine("Programdan cixildi.");
        break;
    }
    else
    {
        Console.WriteLine("Yanlis secim!");
        Pause();
    }
}


static void MenuOperations(IRestaurantService service)
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("===== MENU OPERATIONS =====");
        Console.WriteLine();
        Console.WriteLine("1 - Yeni item elave et");
        Console.WriteLine("2 - Item uzerinde duzelis et");
        Console.WriteLine("3 - Item sil");
        Console.WriteLine("4 - Butun item-lari goster");
        Console.WriteLine("5 - Categoriyasina gore goster");
        Console.WriteLine("6 - Qiymet araligina gore goster");
        Console.WriteLine("7 - Ada gore search");
        Console.WriteLine("0 - Evvelki menuya qayit");
        Console.WriteLine();

        Console.Write("Secim: ");
        string? choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    AddMenuItem(service);
                    break;

                case "2":
                    EditMenuItem(service);
                    break;

                case "3":
                    RemoveMenuItem(service);
                    break;

                case "4":
                    ShowAllMenuItems(service);
                    break;

                case "5":
                    ShowByCategory(service);
                    break;

                case "6":
                    ShowByPrice(service);
                    break;

                case "7":
                    SearchMenuItems(service);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Yanlis secim!");
                    Pause();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"ERROR: {ex.Message}");
            Pause();
        }
    }
}


static void AddMenuItem(IRestaurantService service)
{
    Console.Write("Name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Price: ");
    decimal price = decimal.Parse(Console.ReadLine()!);

    Category category = ReadCategory();

    service.AddMenuItem(
        name,
        price,
        category);

    Console.WriteLine();
    Console.WriteLine("MenuItem ugurla elave edildi.");

    Pause();
}


static void EditMenuItem(IRestaurantService service)
{
    Console.Write("Deyisilecek MenuItem Id: ");
    int id = int.Parse(Console.ReadLine()!);

    Console.Write("Yeni Name: ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Yeni Price: ");
    decimal price = decimal.Parse(Console.ReadLine()!);

    service.EditMenuItem(
        id,
        name,
        price);

    Console.WriteLine();
    Console.WriteLine("MenuItem ugurla deyisdirildi.");

    Pause();
}


static void RemoveMenuItem(IRestaurantService service)
{
    Console.Write("Silinecek MenuItem Id: ");
    int id = int.Parse(Console.ReadLine()!);

    service.RemoveMenuItem(id);

    Console.WriteLine();
    Console.WriteLine("MenuItem silindi.");

    Pause();
}


static void ShowAllMenuItems(IRestaurantService service)
{
    Console.Clear();

    Console.WriteLine("===== ALL MENU ITEMS =====");
    Console.WriteLine();

    if (!service.MenuItems.Any())
    {
        Console.WriteLine("Menu bosdur.");
        Pause();
        return;
    }

    PrintMenuItems(service.MenuItems);

    Pause();
}


static void ShowByCategory(IRestaurantService service)
{
    Category category = ReadCategory();

    List<MenuItem> items =
        service.GetMenuItemsByCategory(category);

    Console.WriteLine();
    Console.WriteLine($"===== {category} =====");

    PrintMenuItems(items);

    Pause();
}


static void ShowByPrice(IRestaurantService service)
{
    Console.Write("Minimum price: ");
    decimal minPrice = decimal.Parse(Console.ReadLine()!);

    Console.Write("Maximum price: ");
    decimal maxPrice = decimal.Parse(Console.ReadLine()!);

    List<MenuItem> items =
        service.GetMenuItemsByPriceInterval(
            minPrice,
            maxPrice);

    Console.WriteLine();
    Console.WriteLine("===== RESULT =====");

    PrintMenuItems(items);

    Pause();
}


static void SearchMenuItems(IRestaurantService service)
{
    Console.Write("Search: ");
    string search = Console.ReadLine() ?? "";

    List<MenuItem> items =
        service.SearchMenuItems(search);

    Console.WriteLine();
    Console.WriteLine("===== SEARCH RESULT =====");

    PrintMenuItems(items);

    Pause();
}


static void OrderOperations(IRestaurantService service)
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("===== ORDER OPERATIONS =====");
        Console.WriteLine();
        Console.WriteLine("1 - Yeni sifaris elave et");
        Console.WriteLine("2 - Sifarisin legvi");
        Console.WriteLine("3 - Butun sifarisleri goster");
        Console.WriteLine("4 - Tarix araligina gore sifarisler");
        Console.WriteLine("5 - Mebleg araligina gore sifarisler");
        Console.WriteLine("6 - Verilmis tarixde olan sifarisler");
        Console.WriteLine("7 - Nomreye esasen sifaris");
        Console.WriteLine("0 - Evvelki menuya qayit");
        Console.WriteLine();

        Console.Write("Secim: ");
        string? choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    AddOrder(service);
                    break;

                case "2":
                    RemoveOrder(service);
                    break;

                case "3":
                    ShowAllOrders(service);
                    break;

                case "4":
                    ShowOrdersByDateInterval(service);
                    break;

                case "5":
                    ShowOrdersByPriceInterval(service);
                    break;

                case "6":
                    ShowOrdersByDate(service);
                    break;

                case "7":
                    ShowOrderById(service);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Yanlis secim!");
                    Pause();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"ERROR: {ex.Message}");
            Pause();
        }
    }
}


static void AddOrder(IRestaurantService service)
{
    Console.Clear();

    Console.WriteLine("===== MENU =====");
    PrintMenuItems(service.MenuItems);

    Dictionary<int, int> orderItems = new();

    while (true)
    {
        Console.WriteLine();
        Console.Write("MenuItem Id (0 - bitir): ");
        int id = int.Parse(Console.ReadLine()!);

        if (id == 0)
            break;

        Console.Write("Count: ");
        int count = int.Parse(Console.ReadLine()!);

        if (orderItems.ContainsKey(id))
        {
            orderItems[id] += count;
        }
        else
        {
            orderItems.Add(id, count);
        }
    }

    service.AddOrder(orderItems);

    Console.WriteLine();
    Console.WriteLine("Sifaris ugurla yaradildi.");

    Pause();
}


static void RemoveOrder(IRestaurantService service)
{
    Console.Write("Legv edilecek Order Id: ");
    int id = int.Parse(Console.ReadLine()!);

    service.RemoveOrder(id);

    Console.WriteLine();
    Console.WriteLine("Sifaris legv edildi.");

    Pause();
}


static void ShowAllOrders(IRestaurantService service)
{
    Console.Clear();

    Console.WriteLine("===== ALL ORDERS =====");
    Console.WriteLine();

    if (!service.Orders.Any())
    {
        Console.WriteLine("Sifaris yoxdur.");
        Pause();
        return;
    }

    PrintOrders(service.Orders);

    Pause();
}


static void ShowOrdersByDateInterval(
    IRestaurantService service)
{
    Console.Write("Start date (yyyy-MM-dd): ");
    DateTime startDate =
        DateTime.Parse(Console.ReadLine()!);

    Console.Write("End date (yyyy-MM-dd): ");
    DateTime endDate =
        DateTime.Parse(Console.ReadLine()!);

    List<Order> orders =
        service.GetOrdersByDatesInterval(
            startDate,
            endDate);

    Console.WriteLine();
    PrintOrders(orders);

    Pause();
}


static void ShowOrdersByPriceInterval(
    IRestaurantService service)
{
    Console.Write("Minimum amount: ");
    decimal min =
        decimal.Parse(Console.ReadLine()!);

    Console.Write("Maximum amount: ");
    decimal max =
        decimal.Parse(Console.ReadLine()!);

    List<Order> orders =
        service.GetOrdersByPriceInterval(
            min,
            max);

    Console.WriteLine();
    PrintOrders(orders);

    Pause();
}


static void ShowOrdersByDate(
    IRestaurantService service)
{
    Console.Write("Date (yyyy-MM-dd): ");
    DateTime date =
        DateTime.Parse(Console.ReadLine()!);

    List<Order> orders =
        service.GetOrderByDate(date);

    Console.WriteLine();
    PrintOrders(orders);

    Pause();
}


static void ShowOrderById(
    IRestaurantService service)
{
    Console.Write("Order Id: ");
    int id = int.Parse(Console.ReadLine()!);

    Order order =
        service.GetOrderByNo(id);

    Console.Clear();

    Console.WriteLine("===== ORDER DETAILS =====");
    Console.WriteLine();

    Console.WriteLine($"Order No: {order.Id}");
    Console.WriteLine($"Total Amount: {order.TotalAmount}");
    Console.WriteLine($"Date: {order.Date}");
    Console.WriteLine(
        $"Menu Item Count: {GetTotalItemCount(order)}");

    Console.WriteLine();
    Console.WriteLine("Order Items:");

    foreach (OrderItem item in order.OrderItems)
    {
        Console.WriteLine(
            $"Id: {item.MenuItem.Id} | " +
            $"Name: {item.MenuItem.Name} | " +
            $"Count: {item.Count}");
    }

    Pause();
}


static void PrintMenuItems(
    IEnumerable<MenuItem> items)
{
    if (!items.Any())
    {
        Console.WriteLine("Netice tapilmadi.");
        return;
    }

    foreach (MenuItem item in items)
    {
        Console.WriteLine(
            $"Id: {item.Id} | " +
            $"Name: {item.Name} | " +
            $"Category: {item.Category} | " +
            $"Price: {item.Price}");
    }
}


static void PrintOrders(
    IEnumerable<Order> orders)
{
    if (!orders.Any())
    {
        Console.WriteLine("Netice tapilmadi.");
        return;
    }

    foreach (Order order in orders)
    {
        Console.WriteLine(
            $"No: {order.Id} | " +
            $"Amount: {order.TotalAmount} | " +
            $"Menu Item Count: {GetTotalItemCount(order)} | " +
            $"Date: {order.Date:yyyy-MM-dd HH:mm}");
    }
}


static int GetTotalItemCount(Order order)
{
    return order.OrderItems.Sum(x => x.Count);
}


static Category ReadCategory()
{
    Console.WriteLine();
    Console.WriteLine("Categories:");

    foreach (Category category in Enum.GetValues<Category>())
    {
        Console.WriteLine(
            $"{(int)category} - {category}");
    }

    Console.Write("Category: ");

    int value =
        int.Parse(Console.ReadLine()!);

    return (Category)value;
}


static void Pause()
{
    Console.WriteLine();
    Console.WriteLine(
        "Davam etmek ucun Enter basin...");

    Console.ReadLine();
}