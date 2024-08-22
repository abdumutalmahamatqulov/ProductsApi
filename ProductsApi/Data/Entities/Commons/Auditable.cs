﻿namespace ProductsApi.Data.Entities.Commons
{
    public class Auditable
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
