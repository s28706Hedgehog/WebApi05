using CShark.Container.LiquidContainerContent;
using CShark.Container.RefrigeratedContainerContent;
using CShark.ContainerContent;
using CShark.ContainerContent.GasContainerContent;
using CShark.ContainerContent.LiquidContainerContent;
using CShark.ContainerContent.ProductContent;
using CShark.ContainerShipContent;

namespace CShark;

static class ContainerMaster
{
    private static bool _endProgram;

    public static void Main(string[] args)
    {
        while (!_endProgram)
        {
            Console.Clear();
            ShowMenu();
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("0 -> To Exit" +
                          "\n1 -> To add new container ship");
        if (ContainerShipManagement.ContainerShips.Count > 0)
        {
            Console.WriteLine("2 -> To remove container ship" +
                              "\n3 -> To create container" +
                              "\n4 -> To load cargo to container" +
                              "\n5 -> To add container to container ship" +
                              "\n6 -> To add container list to container ship" +
                              "\n7 -> To remove container from container ship" +
                              "\n8 -> To unload container cargo" +
                              "\n9 -> To replace container" +
                              "\n10 -> To move container" +
                              "");

            Console.WriteLine("Available container ships:");
            foreach (KeyValuePair<Int32, ContainerShip> valuePair in ContainerShipManagement.ContainerShips)
            {
                Console.Write(valuePair + ", ");
            }

            Console.WriteLine("\n\nAvailable containers: ");
            foreach (KeyValuePair<Int32, Container.Container> container in IContainersStorage.ContainersDic)
            {
                Console.WriteLine(container);
            }

            Console.WriteLine("");
        }

        string? responseString = Console.ReadLine();
        int responseNumb;

        if (int.TryParse(responseString, out int result))
        {
            responseNumb = result;
        }
        else
        {
            Console.WriteLine("Please enter the integer number");
            responseNumb = -1;
        }

        switch (responseNumb)
        {
            case 0:
                _endProgram = true;
                break;
            case 1:
                OptionAddContainerShip();
                break;
            case 2:
                OptionContainerShipRemove();
                break;
            case 3:
                OptionCreateContainer();
                break;
            case 4:
                OptionLoadCargo();
                break;
            case 5:
                OptionAddContainerToContainerShip();
                break;
            case 6:
                OptionAddContainerListToContainerShip();
                break;
            case 7:
                OptionRemoveContainerFromContainerShip();
                break;
            case 8:
                OptionUnloadContainerCargo();
                break;
            case 9:
                OptionReplaceContainer();
                break;
            case 10:
                

            default:
                Console.WriteLine("Wrong choice");
                Console.ReadKey();
                break;
        }
    }

    private static void OptionAddContainerShip()
    {
        Console.WriteLine("Please enter the container ship details in the following format:");
        Console.WriteLine("Name-MaxSpeed-MaxContainerCapacity-MaxContainersWeight");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] containerShipData = input.Split('-');

        if (containerShipData.Length != 4)
        {
            Console.WriteLine("There should be 4 data, there': " + containerShipData.Length);
            Console.ReadKey();
            return;
        }

        string name = containerShipData[0];
        if (!double.TryParse(containerShipData[1], out double maxSpeed))
        {
            Console.WriteLine("Invalid input for MaxSpeed.");
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(containerShipData[2], out int maxContainerCapacity))
        {
            Console.WriteLine("Invalid input for MaxContainerCapacity.");
            Console.ReadKey();
            return;
        }

        if (!double.TryParse(containerShipData[3], out double maxContainersWeight))
        {
            Console.WriteLine("Invalid input for MaxContainersWeight.");
            Console.ReadKey();
            return;
        }

        ContainerShip newShip = new ContainerShip(name, maxSpeed, maxContainerCapacity, maxContainersWeight);
        Console.WriteLine("Container ship " + newShip.Name + " created successfully");
    }

    private static void OptionContainerShipRemove()
    {
        Console.WriteLine("Please enter the Id of container ship you would like to remove");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        if (!int.TryParse(input, out int id))
        {
            Console.WriteLine("Invalid input for Container Ship Id: " + id);
            Console.ReadKey();
            return;
        }

        ContainerShipManagement.ContainerShips.Remove(id);
    }

    private static void OptionCreateContainer()
    {
        //Console.WriteLine("Please provide the id of Container Ship for transport");
        //
        //if (!int.TryParse(Console.ReadLine(), out int containerShipId))
        //{
        //    Console.WriteLine("Invalid input for containerShipId.");
        //    Console.ReadKey();
        //    return;
        //}

        Console.WriteLine("Please enter the type of container you would like to create");
        Console.WriteLine("Available types: L, G, C, HL");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        // Container actually added to the Dictionary
        ContainerManagement.CreateContainer(input);
    }

    private static void OptionLoadCargo()
    {
        Console.WriteLine("Please enter the Id of container and cargo: id-cargo");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] respond = input.Split('-');
        if (respond.Length != 2)
        {
            Console.WriteLine("Inappropriate number of variables: " + respond.Length);
            Console.Read();
            return;
        }

        if (!int.TryParse(respond[0], out int id))
        {
            Console.WriteLine("Invalid input for Container Id: " + id);
            Console.ReadKey();
            return;
        }

        if (!double.TryParse(respond[1], out double cargo))
        {
            Console.WriteLine("Invalid input for Container cargo: " + cargo);
            Console.ReadKey();
            return;
        }

        IContainersStorage.ContainersDic[id].LoadCargo(cargo);
    }

    private static void OptionAddContainerToContainerShip()
    {
        Console.WriteLine("Please enter the Id of container and id of container ship: " +
                          "idContainer-idContainerShip");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] respond = input.Split('-');
        if (respond.Length != 2)
        {
            Console.WriteLine("Inappropriate number of variables: " + respond.Length);
            Console.Read();
            return;
        }

        if (!int.TryParse(respond[0], out int idContainer))
        {
            Console.WriteLine("Invalid input for Container Id: " + idContainer);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(respond[1], out int idContainerShip))
        {
            Console.WriteLine("Invalid input for Container Ship id: " + idContainerShip);
            Console.ReadKey();
            return;
        }

        ContainerShipManagement.ContainerShips[idContainerShip].AddContainer(
            IContainersStorage.ContainersDic[idContainer]);
    }

    private static void OptionAddContainerListToContainerShip()
    {
        Console.WriteLine("Please enter the Id of container ship");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        if (!int.TryParse(input, out int idContainerShip))
        {
            Console.WriteLine("Invalid input for Container Ship id: " + idContainerShip);
            Console.ReadKey();
            return;
        }

        ContainerShipManagement.ContainerShips[idContainerShip].AddContainerList(_containers);
    }

    private static void OptionRemoveContainerFromContainerShip()
    {
        Console.WriteLine("Please enter the Id of Container and Container Ship\n" +
                          "containerId-ContainerShipId");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] respond = input.Split('-');
        if (respond.Length != 2)
        {
            Console.WriteLine("Inappropriate number of variables: " + respond.Length);
            Console.Read();
            return;
        }

        if (!int.TryParse(respond[0], out int idContainer))
        {
            Console.WriteLine("Invalid input for container Id: " + idContainer);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(respond[0], out int idContainerShip))
        {
            Console.WriteLine("Invalid input for container ship Id: " + idContainerShip);
            Console.ReadKey();
            return;
        }

        Container.Container containerTmp = null;

        foreach (Container.Container container in
                 ContainerShipManagement.ContainerShips[idContainerShip].ContainerList)
        {
            if (container.GetId() == idContainer)
            {
                containerTmp = container;
                break;
            }
        }

        if (containerTmp != null)
        {
            ContainerShipManagement.ContainerShips[idContainerShip].ContainerList.Remove(containerTmp);
            Console.WriteLine("Container removed");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("There's no such a container avaiable");
            Console.ReadKey();
        }
    }
    private static void OptionUnloadContainerCargo()
    {
        Console.WriteLine("Please enter the Id of container");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        if (!int.TryParse(input, out int idContainer))
        {
            Console.WriteLine("Invalid input for container Id: " + idContainer);
            Console.ReadKey();
            return;
        }

        IContainersStorage.ContainersDic[idContainer].UnloadCargo();
    }
    private static void OptionReplaceContainer()
    {
        Console.WriteLine("Please enter the Id of container to be replaced, the id of the new container " +
                          "and id of Container Ship" +
                          "\noldContainerId-newContainerId-ContainerShip");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] response = input.Split('-');

        if (response.Length != 3)
        {
            Console.WriteLine("Should be 3 variables, actually: " + response.Length);
            Console.ReadKey();
        }

        if (!int.TryParse(response[0], out int oldContainerId))
        {
            Console.WriteLine("Invalid input for old container Id: " + oldContainerId);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(response[1], out int newContainerId))
        {
            Console.WriteLine("Invalid input for new container Id: " + newContainerId);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(response[2], out int containerShipId))
        {
            Console.WriteLine("Invalid input for containerShipId Id: " + newContainerId);
            Console.ReadKey();
            return;
        }

        ContainerShipManagement.ContainerShips[containerShipId]
            .replaceContainer(oldContainerId, IContainersStorage.ContainersDic[newContainerId]);
        Console.WriteLine("Container replaced");
        Console.ReadKey();
    }
    
    private static void OptionMoveContainer()
    {
        Console.WriteLine("Please enter the Id of container to be moved, the id of the new ContainerShip " +
                          "and id of OldContainerShip" +
                          "\nContainerId-newContainerShip-OldContainerShip");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        string[] response = input.Split('-');

        if (response.Length != 3)
        {
            Console.WriteLine("Should be 3 variables, actually: " + response.Length);
            Console.ReadKey();
        }

        if (!int.TryParse(response[0], out int containerId))
        {
            Console.WriteLine("Invalid input for old container Id: " + containerId);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(response[1], out int newContainerShipId))
        {
            Console.WriteLine("Invalid input for newContainerShip Id: " + newContainerShipId);
            Console.ReadKey();
            return;
        }

        if (!int.TryParse(response[2], out int oldContainerShipId))
        {
            Console.WriteLine("Invalid input for oldContainerShipId Id: " + oldContainerShipId);
            Console.ReadKey();
            return;
        }

        ContainerShipManagement.ContainerShips[0]
            .replaceContainer(0, IContainersStorage.ContainersDic[0]);
        Console.WriteLine("Container replaced");
        Console.ReadKey();
    }

    private static List<Container.Container> _containers =
        new Container.Container[]
        {
            new GasContainer(500, 1600, 1200, 50_000, 24.5),
            new GasContainer(500, 800, 1200, 200_000, 12422.31),
            new LiquidContainer(300, 900, 1237.1237, 1234),
            new HazardLiquidContainer(499.99, 766.823, 222.332, 942),
            new RefrigeratedContainer(400, 755, 444.555, 888, Product.Fish, -99)
        }.ToList();
}