using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class DataContext: DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CategoriesProducts;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity() { Id = 1, Name = "Овощи и фрукты" },
                new CategoryEntity() { Id = 2, Name = "Кондитерская продукция" },
                new CategoryEntity() { Id = 3, Name = "Хлебобулочные изделия" },
                new CategoryEntity() { Id = 4, Name = "Свежий продукт" }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity() { Id = 1, Name = "Хлеб", Price = 54.99, Description = "Состав: Мука пшеничная 1 сорта, хлопья овсяные, хлопья ячменные, хлопья ржаные, семя подсолнечника, мука ржаная обдирная, солод, вода, сахар, соль" },
                new ProductEntity() { Id = 2, Name = "Соломка соленая", Price = 73.99, Description = "Состав: мука пшеничная, крахмал, гидрогенизированное растительное масло, соль, солод, сахар, разрыхлитель Е503 (ii), эмульгатор Е322, дрожжи, регулятор кислотности Е524" },
                new ProductEntity() { Id = 3, Name = "Огурцы тепличные", Price = 122.99, Description = "Цена указана за килограмм" },
                new ProductEntity() { Id = 4, Name = "Торт", Price = 399.99, Description = "Состав: мука пшеничная, яйцо куриное, сахар песок, масло сливочное, молоко цельное, патока, соль" },
                new ProductEntity() { Id = 5, Name = "Ложка", Price = 219.49, Description = "Нержавеющая сталь" }
            );

            modelBuilder.Entity("CategoryEntityProductEntity").ToTable("CategoryProduct").HasData(
                new { CategoriesId = 1, ProductsId = 3 },
                new { CategoriesId = 2, ProductsId = 4 },
                new { CategoriesId = 3, ProductsId = 1 },
                new { CategoriesId = 3, ProductsId = 2 },
                new { CategoriesId = 4, ProductsId = 1 },
                new { CategoriesId = 4, ProductsId = 3 }
            );
        }

    }
}
