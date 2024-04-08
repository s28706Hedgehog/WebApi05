using CShark.ContainerContent;

namespace CShark.Container.LiquidContainerContent;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double height, double weight, double depth, double maxCargoWeight) 
        : base(height, weight, depth, "L", maxCargoWeight)
    {
        RegisterContainer(GetId(), this);
    }

    public override void UnloadCargo()
    {
        CargoWeight = 0;
        Console.WriteLine("Empty cargo: 0, for: " + SerialNumber);
    }

    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight * 0.9)
        {
            SendHazardNotification("Warning! Container may contain only 90% of his maxCargoWeight, current weight: " + cargoWeight/MaxCargoWeight, GetId());
            // throw new OverfillException("Container may contain only 90% of his maxCargoWeight");
        }
        CargoWeight = cargoWeight;
        Console.WriteLine("Load cargo: " + cargoWeight + ", for: " + SerialNumber);
    }

    public void SendHazardNotification(string message, int containerId)
    {
        Console.WriteLine(message + containerId);
    }
    
    public override void RegisterContainer(int containerId, Container container)
    {
        IContainersStorage.ContainersDic.Add(containerId, container);
    }
    
    public override string ToString()
    {
        return $"[LiquidContainer Height: {Height}, Weight: {Weight}, Depth: {Depth}, MaxCargoWeight: {MaxCargoWeight}]";
    }
}