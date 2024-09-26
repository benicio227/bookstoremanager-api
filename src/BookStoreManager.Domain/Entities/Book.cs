namespace BookStoreManager.Domain.Entities;
public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string GenderType { get; set; } = string.Empty;
    public int Stock {  get; set; }
}
