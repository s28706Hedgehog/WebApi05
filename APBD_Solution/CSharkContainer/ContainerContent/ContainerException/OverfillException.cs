namespace CShark.Container;

public class OverfillException : Exception
{
    public OverfillException()
        : base(){
    }
    public OverfillException(string message)
        : base(message){
    }
}