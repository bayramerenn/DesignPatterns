using CommandPattern.Sample2;


var modifyPrice = new ModifyPrice();
var product = new Product("Phone", 500);

Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
Execute(modifyPrice, new ProductCommand(product, PriceAction.Decrease, 20));
Console.WriteLine(product);
void Execute(ModifyPrice modifyPrice, ICommand command)
{
    modifyPrice.SetCommand(command);
    modifyPrice.Invoke();
}