namespace CShark.ContainerContent.ProductContent;

// https://stackoverflow.com/questions/22054679/how-to-have-an-enum-store-extra-info-on-each-of-its-entry
public class Product
{
    public string Name { private set; get; }
    public double Temperature { private set; get; }

    public static Product Bananas = new Product() { Name = "Bananas", Temperature = 13.3 };
    public static Product Chocolate = new Product() { Name = "Chocolate", Temperature = 18 };
    public static Product Fish = new Product() { Name = "Fish", Temperature = 2 };
    public static Product Meat = new Product() { Name = "Meat", Temperature = -15 };
    public static Product IceCream = new Product() { Name = "Ice Cream", Temperature = -18 };
    public static Product FrozenPizza = new Product() { Name = "Frozen Pizza", Temperature = -30 };
    public static Product Cheese = new Product() { Name = "Cheese", Temperature = 7.2 };
    public static Product Sausages = new Product() { Name = "Sausages", Temperature = 5 };
    public static Product Butter = new Product() { Name = "Butter", Temperature = 20.5 };
    public static Product Eggs = new Product() { Name = "Eggs", Temperature = 19 };
}