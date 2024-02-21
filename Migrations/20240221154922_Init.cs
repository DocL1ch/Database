using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Овощи и фрукты" },
                    { 2, "Кондитерская продукция" },
                    { 3, "Хлебобулочные изделия" },
                    { 4, "Свежий продукт" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Состав: Мука пшеничная 1 сорта, хлопья овсяные, хлопья ячменные, хлопья ржаные, семя подсолнечника, мука ржаная обдирная, солод, вода, сахар, соль", "Хлеб", 54.990000000000002 },
                    { 2, "Состав: мука пшеничная, крахмал, гидрогенизированное растительное масло, соль, солод, сахар, разрыхлитель Е503 (ii), эмульгатор Е322, дрожжи, регулятор кислотности Е524", "Соломка соленая", 73.989999999999995 },
                    { 3, "Цена указана за килограмм", "Огурцы тепличные", 122.98999999999999 },
                    { 4, "Состав: мука пшеничная, яйцо куриное, сахар песок, масло сливочное, молоко цельное, патока, соль", "Торт", 399.99000000000001 },
                    { 5, "Нержавеющая сталь", "Ложка", 219.49000000000001 }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
