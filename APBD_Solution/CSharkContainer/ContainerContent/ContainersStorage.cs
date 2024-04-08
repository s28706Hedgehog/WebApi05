namespace CShark.ContainerContent;

public interface IContainersStorage
{
    public static readonly Dictionary<Int32, Container.Container> ContainersDic = new Dictionary<int, Container.Container>();

    protected abstract void RegisterContainer(int containerId, Container.Container container);
}