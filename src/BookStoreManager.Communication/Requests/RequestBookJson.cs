﻿namespace BookStoreManager.Communication.Requests;
public class RequestBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author {  get; set; } = string.Empty;
    public string GenderType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
