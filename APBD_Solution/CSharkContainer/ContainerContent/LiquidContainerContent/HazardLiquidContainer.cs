using CShark.Container.LiquidContainerContent;

namespace CShark.ContainerContent.LiquidContainerContent;

public class HazardLiquidContainer : Container.Container, IHazardNotifier
{
    public HazardLiquidContainer(double height, double weight, double depth, double maxCargoWeight) 
        : base(height, weight, depth, "HL", maxCargoWeight)
    {
        RegisterContainer(GetId(), this);
    }

    public override void UnloadCargo()
    {
        CargoWeight = 0;
        Console.WriteLine("Empty cargo: " + CargoWeight + ", for: " + SerialNumber);
    }

    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight / 2)
        {
            SendHazardNotification("Warning! Container may contain only 50% of his maxCargoWeight, current weight: " + cargoWeight/MaxCargoWeight, GetId());
        }
        CargoWeight = cargoWeight;
        Console.WriteLine("Load cargo: " + cargoWeight + ", for: " + SerialNumber);
    }

    public void SendHazardNotification(string message, int containerId)
    {
        Console.WriteLine(message + containerId);
    }
    
    public override void RegisterContainer(int containerId, Container.Container container)
    {
        IContainersStorage.ContainersDic.Add(containerId, container);
    }
    
    public override string ToString()
    {
        return $"[HazardLiquidContainer Height: {Height}, Weight: {Weight}, Depth: {Depth}, MaxCargoWeight: {MaxCargoWeight}]";
    }
}