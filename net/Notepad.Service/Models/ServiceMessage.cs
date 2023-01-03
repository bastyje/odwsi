namespace Notepad.Service.Models;

public class ServiceMessage<T> : ServiceMessage
{
    public T Content { get; set; }
}

public class ServiceMessage
{
    public ServiceMessage()
    {
        Errors = new List<ErrorMessage>();
    }
    
    public List<ErrorMessage> Errors { get; set; }
    public bool Success => Errors.Count == 0;
    
}