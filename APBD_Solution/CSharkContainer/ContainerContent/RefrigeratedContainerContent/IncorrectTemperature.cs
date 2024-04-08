namespace CShark.Container.RefrigeratedContainerContent;

public class IncorrectTemperature : Exception
{
    public IncorrectTemperature()
        : base(){
    }
    public IncorrectTemperature(string message)
        : base(message){
    }
}