using CShark.Container;
using CShark.Container.LiquidContainerContent;

namespace CShark.ContainerContent.GasContainerContent;

public class GasContainer : Container.Container, IHazardNotifier
{
    private double GasPressure { get; set; }

    public GasContainer(double height, double weight, double depth, double maxCargoWeight, double gasPressure) 
        : base(height, weight, depth, "G", maxCargoWeight)
    {
        if (gasPressure > 100)
        {
            SendHazardNotification("Warning! High gasPressure!", GetId());
        }

        GasPressure = gasPressure;
        RegisterContainer(GetId(), this);
    }

    public override void UnloadCargo()
    {
        CargoWeight *= 0.05;
        Console.WriteLine("Empty cargo: " + CargoWeight + ", for: " + SerialNumber);
    }

    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
        {
            throw new OverfillException();    
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
        return $"[GasContainer Height: {Height}, Weight: {Weight}, Depth: {Depth}, MaxCargoWeight: {MaxCargoWeight}, GasPressure: {GasPressure}]";
    }
}