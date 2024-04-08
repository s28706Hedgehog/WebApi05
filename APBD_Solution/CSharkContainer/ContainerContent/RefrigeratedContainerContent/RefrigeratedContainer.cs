using CShark.ContainerContent;
using CShark.ContainerContent.ProductContent;

namespace CShark.Container.RefrigeratedContainerContent;

public class RefrigeratedContainer : Container
{
    private Product ProductType { get; set; }
    private double ContainerTemperature { get; set; }

    public RefrigeratedContainer(double height, double weight, double depth, double maxCargoWeight, Product productType, double containerTemperature) 
        : base(height, weight, depth, "C", maxCargoWeight)
    {
        ProductType = productType;
        ContainerTemperature = containerTemperature;
        RegisterContainer(GetId(), this);
    }

    public override void UnloadCargo()
    {
        CargoWeight = 0;
        Console.WriteLine("Empty cargo: " + CargoWeight + ", for: " + SerialNumber);
    }

    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
        {
            throw new OverfillException();    
        }

        if (ProductType.Temperature < ContainerTemperature)
        {
            throw new IncorrectTemperature("Temperature of product can not be lower then temperature of container!");
        }

        CargoWeight = cargoWeight;
        Console.WriteLine("Load cargo: " + cargoWeight + ", for: " + SerialNumber);
    }

    public override void RegisterContainer(int containerId, Container container)
    {
        IContainersStorage.ContainersDic.Add(containerId, container);
    }

    public override string ToString()
    {
        return $"[LiquidContainer Height: {Height}, Weight: {Weight}, Depth: {Depth}, MaxCargoWeight: {MaxCargoWeight}, " +
               $"ProductType: {ProductType.Name}, ContainerTemperature: {ContainerTemperature}]";
    }
}