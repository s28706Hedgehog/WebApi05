namespace CShark.Container.LiquidContainerContent;

public interface IHazardNotifier
{
    void SendHazardNotification(string message, int containerId);
}