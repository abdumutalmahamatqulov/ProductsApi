﻿namespace ProductsApi.Data.Entities;

public class Category 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
}
