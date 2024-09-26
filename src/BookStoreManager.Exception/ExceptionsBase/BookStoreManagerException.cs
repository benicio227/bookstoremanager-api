namespace BookStoreManager.Exception.ExceptionsBase;
public abstract class BookStoreManagerException : SystemException
{
    protected BookStoreManagerException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode {  get; }
    public abstract List<string> GetErrors();
}
