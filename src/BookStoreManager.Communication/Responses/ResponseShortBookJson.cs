namespace BookStoreManager.Communication.Responses;
public class ResponseShortBookJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author {  get; set; } = string.Empty;
    public int Stock {  get; set; }
}
