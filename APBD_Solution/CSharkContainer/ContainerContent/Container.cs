using CShark.Container.RefrigeratedContainerContent;
using CShark.ContainerContent;

namespace CShark.Container;

public abstract class Container : IContainersStorage
{
    protected double CargoWeight { get; set; }
    protected double Height { get; }
    protected double Weight { get; }
    protected double Depth { get; }
    protected string SerialNumber { get; }
    protected double MaxCargoWeight { get; }

    private static int _containerId = 1;
    
    protected Container(double height, double weight, double depth, string containerType, double maxCargoWeight)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = "KON-" + containerType + '-' + _containerId++;
        MaxCargoWeight = maxCargoWeight;
    }

    public abstract void UnloadCargo();
    public int GetId()
    {
        if (Int32.TryParse(SerialNumber.Split('-')[2], out int id))
        {
            return id;
        }
        else
        {
            throw new IncorrectSerialNumberFormatException("Incorrect serial number: " + SerialNumber);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cargoWeight"></param>
    /// <exception cref="OverfillException"> Thrown when cargo is bigger then MaxCargoWeight </exception>
    public abstract void LoadCargo(double cargoWeight); // Kinda weird that there's no 'throws exception'

    public abstract void RegisterContainer(int containerId, Container container);
}