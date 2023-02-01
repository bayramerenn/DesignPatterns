
using System.Collections.Generic;

DineChef dineChef = new DineChef();
dineChef.SetOrderCommand(DineEnums.New);
dineChef.SetMenuItem(new MenuItem()
{
    TableNumber = 1,
    Item = "Super Mega Burger",
    Quantity = 1,
    Tags = new List<Tag>() { new Tag() { TagName = "Jalapenos," }, new Tag() { TagName = " Cheese," }, new Tag() { TagName = " Tomato" } }
});
dineChef.ExecuteCommand();

dineChef.SetMenuItem(new MenuItem()
{
    TableNumber = 1,
    Item = "Cheese Sandwich",
    Quantity = 1,
    Tags = new List<Tag>() { new Tag() { TagName = "Spicy Mayo," } }
});

dineChef.ExecuteCommand();
dineChef.ShowCurrentOrder();


public class Tag
{
    public string TagName { get; set; }
}

public class MenuItem
{
    public string Item { get; set; }
    public int Quantity { get; set; }
    public int TableNumber { get; set; }
    public List<Tag> Tags { get; set; }

    public void DisplayOrder()
    {
        Console.WriteLine("Table No: " + TableNumber);
        Console.WriteLine("Item: " + Item);
        Console.WriteLine("Quantity: " + Quantity);
        Console.Write("\tTags: ");
        foreach (var item in Tags)
        {
            Console.Write(item.TagName);
        }
    }
}

public abstract class OrderCommand
{
    public abstract void Execute(List<MenuItem> order, MenuItem newItem);
}

public class NewOrderCommand : OrderCommand
{
    public override void Execute(List<MenuItem> order, MenuItem newItem)
    {
        order.Add(newItem);
    }
}

public class RemoveOrderCommand : OrderCommand
{
    public override void Execute(List<MenuItem> order, MenuItem newItem)
    {
        order.Remove(newItem);
    }
}

public class ModifyOrderCommand : OrderCommand
{
    public override void Execute(List<MenuItem> order, MenuItem newItem)
    {
        var menuItem = order.Where(m => m.Item == newItem.Item).FirstOrDefault();
        menuItem.Item = newItem.Item;
        menuItem.Quantity = newItem.Quantity;
        menuItem.TableNumber = newItem.TableNumber;
        menuItem.Tags = newItem.Tags;
    }
}

public class DineChefRestaurant
{
    public List<MenuItem> Orders { get; set; }

    public DineChefRestaurant()
    {
        Orders ??= new List<MenuItem>();
    }

    public void ExecuteCommand(OrderCommand command, MenuItem menuItem)
    {
        command.Execute(this.Orders, menuItem);
    }

    public void ShorOrders()
    {
        Orders.ForEach(o =>
        {
            o.DisplayOrder();
        });
    }
}

public class DineChef
{
    private DineChefRestaurant order;
    private OrderCommand orderCommand;
    private MenuItem menuItem;

    public DineChef()
    {
        order = new DineChefRestaurant();
    }

    public void SetOrderCommand(DineEnums dineEnums)
    {
        orderCommand = new DineTableCommand().GetDineCommand(dineEnums);
    }

    public void SetMenuItem(MenuItem item)
    {
        menuItem = item;
    }

    public void ExecuteCommand()
    {
        order.ExecuteCommand(orderCommand, menuItem);
    }

    public void ShowCurrentOrder() => order.ShorOrders();
}

public class DineTableCommand
{
    public OrderCommand GetDineCommand(DineEnums dineEnums)
    {
        switch (dineEnums)
        {
            case DineEnums.New:
                return new NewOrderCommand();

            case DineEnums.Modify:
                return new ModifyOrderCommand();

            case DineEnums.Remove:
                return new RemoveOrderCommand();

            default:
                return new NewOrderCommand();
        }
    }
}

public enum DineEnums
{
    New,
    Modify,
    Remove
}