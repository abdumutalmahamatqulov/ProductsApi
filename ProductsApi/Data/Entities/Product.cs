﻿namespace ProductsApi.Data.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int DisCount { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreateData { get; set; }
    public Category Category { get; set; }
}
