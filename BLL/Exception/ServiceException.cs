namespace BLL.Exception;

public class ServiceException : System.Exception
{
    public ServiceException(string obj, string value) : base(obj + " " + value + " could not be found.")
    {
    }
}