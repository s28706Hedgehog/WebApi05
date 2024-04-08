namespace CShark.ContainerContent.ProductContent;

public class ProductManagement
{
    public static Dictionary<string, Product> NameProducts { get; } = new Dictionary<string, Product>();

    public ProductManagement()
    {
        NameProducts.Add(Product.Bananas.Name, Product.Bananas);
        NameProducts.Add(Product.Chocolate.Name, Product.Chocolate);
        NameProducts.Add(Product.Fish.Name, Product.Fish);
        NameProducts.Add(Product.Meat.Name, Product.Meat);
        NameProducts.Add(Product.IceCream.Name, Product.IceCream);
        NameProducts.Add(Product.FrozenPizza.Name, Product.FrozenPizza);
        NameProducts.Add(Product.Cheese.Name, Product.Cheese);
        NameProducts.Add(Product.Sausages.Name, Product.Sausages);
        NameProducts.Add(Product.Butter.Name, Product.Butter);
        NameProducts.Add(Product.Eggs.Name, Product.Eggs);
    }
}