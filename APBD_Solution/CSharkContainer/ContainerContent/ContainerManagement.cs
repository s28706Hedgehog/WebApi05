using CShark.Container.LiquidContainerContent;
using CShark.Container.RefrigeratedContainerContent;
using CShark.ContainerContent.GasContainerContent;
using CShark.ContainerContent.LiquidContainerContent;
using CShark.ContainerContent.ProductContent;

namespace CShark.ContainerContent;

public class ContainerManagement
{
    public static Container.Container? CreateContainer(string containerType)
    {
        Container.Container? resultContainer = null;
        if (containerType.Equals("G"))
        {
            resultContainer = OptionAddGasContainer();
        }
        else if (containerType.Equals("HL"))
        {
            resultContainer = OptionAddHazardLiquidContainer();
        }
        else if (containerType.Equals("L"))
        {
            resultContainer = OptionAddLiquidContainer();
        }
        else if (containerType.Equals("C"))
        {
            resultContainer = OptionAddRefrigeratedContainer();
        }

        if (resultContainer != null)
        {
            Console.WriteLine("Container " + resultContainer + " created successfully");
        }
        else
        {
            Console.WriteLine("Failed to create new Container");
            Console.ReadKey();
        }

        return resultContainer;
    }

    private static Container.Container? OptionAddRefrigeratedContainer()
    {
        Console.WriteLine("Please enter the container details in the following format:");
        Console.WriteLine("height-weight-depth-maxCargoWeight-productType-containerTemperature");
        Console.WriteLine(
            "Available product names: Bananas, Chocolate, Fish, Meat, Ice Cream, Frozen Pizza, Cheese, Sausages, Butter, Eggs");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return null;
        }

        string[] containerShipData = input.Split('-');

        if (containerShipData.Length != 6)
        {
            Console.WriteLine("There should be 6 data, there': " + containerShipData.Length);
            Console.ReadKey();
            return null;
        }


        if (!double.TryParse(containerShipData[0], out double height))
        {
            Console.WriteLine("Invalid input for height.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[1], out double weight))
        {
            Console.WriteLine("Invalid input for weight.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[2], out double depth))
        {
            Console.WriteLine("Invalid input for depth.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[3], out double maxCargoWeight))
        {
            Console.WriteLine("Invalid input for maxCargoWeight.");
            Console.ReadKey();
            return null;
        }

        Product productType = ProductManagement.NameProducts[containerShipData[4]];

        if (!double.TryParse(containerShipData[5], out double containerTemperature))
        {
            Console.WriteLine("Invalid input for maxCargoWeight.");
            Console.ReadKey();
            return null;
        }

        return new RefrigeratedContainer(height, weight, depth, maxCargoWeight, productType, containerTemperature);
    }

    private static Container.Container? OptionAddLiquidContainer()
    {
        Console.WriteLine("Please enter the container details in the following format:");
        Console.WriteLine("height-weight-depth-maxCargoWeight");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return null;
        }

        string[] containerShipData = input.Split('-');

        if (containerShipData.Length != 4)
        {
            Console.WriteLine("There should be 4 data, there': " + containerShipData.Length);
            Console.ReadKey();
            return null;
        }


        if (!double.TryParse(containerShipData[0], out double height))
        {
            Console.WriteLine("Invalid input for height.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[1], out double weight))
        {
            Console.WriteLine("Invalid input for weight.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[2], out double depth))
        {
            Console.WriteLine("Invalid input for depth.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[3], out double maxCargoWeight))
        {
            Console.WriteLine("Invalid input for maxCargoWeight.");
            Console.ReadKey();
            return null;
        }

        return new LiquidContainer(height, weight, depth, maxCargoWeight);
    }

    private static Container.Container? OptionAddHazardLiquidContainer()
    {
        Console.WriteLine("Please enter the container details in the following format:");
        Console.WriteLine("height-weight-depth-maxCargoWeight");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return null;
        }

        string[] containerShipData = input.Split('-');

        if (containerShipData.Length != 4)
        {
            Console.WriteLine("There should be 4 data, there': " + containerShipData.Length);
            Console.ReadKey();
            return null;
        }


        if (!double.TryParse(containerShipData[0], out double height))
        {
            Console.WriteLine("Invalid input for height.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[1], out double weight))
        {
            Console.WriteLine("Invalid input for weight.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[2], out double depth))
        {
            Console.WriteLine("Invalid input for depth.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[3], out double maxCargoWeight))
        {
            Console.WriteLine("Invalid input for maxCargoWeight.");
            Console.ReadKey();
            return null;
        }

        return new HazardLiquidContainer(height, weight, depth, maxCargoWeight);
    }

    private static Container.Container? OptionAddGasContainer()
    {
        Console.WriteLine("Please enter the container details in the following format:");
        Console.WriteLine("height-weight-depth-maxCargoWeight-gasPressure");

        string? input = Console.ReadLine();
        if (input == null)
        {
            return null;
        }

        string[] containerShipData = input.Split('-');

        if (containerShipData.Length != 5)
        {
            Console.WriteLine("There should be 5 data, there': " + containerShipData.Length);
            Console.ReadKey();
            return null;
        }


        if (!double.TryParse(containerShipData[0], out double height))
        {
            Console.WriteLine("Invalid input for height.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[1], out double weight))
        {
            Console.WriteLine("Invalid input for weight.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[2], out double depth))
        {
            Console.WriteLine("Invalid input for depth.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[3], out double maxCargoWeight))
        {
            Console.WriteLine("Invalid input for maxCargoWeight.");
            Console.ReadKey();
            return null;
        }

        if (!double.TryParse(containerShipData[3], out double gasPressure))
        {
            Console.WriteLine("Invalid input for gasPressure.");
            Console.ReadKey();
            return null;
        }

        return new GasContainer(height, weight, depth, maxCargoWeight, gasPressure);
    }
}