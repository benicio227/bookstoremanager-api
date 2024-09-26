using System.Net;

namespace BookStoreManager.Exception.ExceptionsBase;
public class NotFoundException : BookStoreManagerException
{
    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }
}
