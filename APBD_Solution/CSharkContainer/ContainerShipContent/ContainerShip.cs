using System.Collections;

namespace CShark.ContainerShipContent;


public class ContainerShip
{
    public List<Container.Container> ContainerList { get; } = new();
    public string Name { get; set; }
    private double MaxSpeed { get; }
    private int MaxContainerCapacity { get; }
    private double MaxContainersWeight { get; }

    public ContainerShip(string name, double maxSpeed, int maxContainerCapacity, double maxContainersWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCapacity = maxContainerCapacity;
        MaxContainersWeight = maxContainersWeight;
        ContainerShipManagement.AddContainerShip(this);
    }

    public void AddContainer(Container.Container container)
    {
        ContainerList.Add(container);
    }

    public void AddContainerList(List<Container.Container> list)
    {
        foreach (Container.Container container in list)
        {
            this.AddContainer(container);
        }
    }

    public void replaceContainer(int containerId, Container.Container newCont)
    {
        removeContainer(containerId);
        this.ContainerList.Add(newCont);
    }

    public void removeContainer(int containerId)
    {
        Container.Container tmpContainer = null;
        
        foreach (Container.Container container in this.ContainerList)
        {
            if (container.GetId() == containerId)
            {
                tmpContainer = container;
                break;
            }
        }

        if (tmpContainer == null)
        {
            return;
        }

        this.ContainerList.Remove(tmpContainer);
    }

    public override string ToString()
    {
        return "[" + Name + ", MaxSpeed=," + MaxSpeed + ", maxContainerNum=" + MaxContainerCapacity +", maxWeight=" + MaxContainersWeight + ", available containers: " + ContainerList.Count + "]";
    }
}