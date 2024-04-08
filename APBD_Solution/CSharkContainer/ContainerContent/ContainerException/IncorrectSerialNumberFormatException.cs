namespace CShark.Container.RefrigeratedContainerContent;

public class IncorrectSerialNumberFormatException : Exception
{
    public IncorrectSerialNumberFormatException()
        : base(){
    }
    public IncorrectSerialNumberFormatException(string message)
        : base(message){
    }
}