﻿namespace Records.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
