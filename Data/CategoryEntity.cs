﻿namespace Database.Data
{
    public class CategoryEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
