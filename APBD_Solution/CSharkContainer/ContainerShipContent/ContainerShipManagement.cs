using Microsoft.VisualBasic.CompilerServices;

namespace CShark.ContainerShipContent;

public class ContainerShipManagement
{
    // https://stackoverflow.com/questions/1273139/c-sharp-java-hashmap-equivalent
    // public static List<ContainerShip> ContainerShips { get; } = new List<ContainerShip>();
    private static int ContainerShipId = 1;
    public static Dictionary<Int32, ContainerShip> ContainerShips { get; } =
        new Dictionary<Int32, ContainerShip>();

    public static void AddContainerShip(ContainerShip containerShip)
    {
        ContainerShips.Add(ContainerShipId++, containerShip);        
    }
}