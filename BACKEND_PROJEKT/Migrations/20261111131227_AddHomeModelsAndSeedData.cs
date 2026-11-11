using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKEND_PROJEKT.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeModelsAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Image", "Name", "OldPrice", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "Men", "product-1.jpg", "Flowers Red & Green Shoe", 100.00m, 80.00m, 5 },
                    { 2, "Men", "product-2.jpg", "Simple Blue & White Shoe", 90.00m, 70.00m, 5 },
                    { 3, "Women", "product-3.jpg", "Red Leather Sport Shoe", 85.00m, 60.00m, 4 },
                    { 4, "Sports", "product-4.jpg", "Primitive Knost Sport Shoe", 110.00m, 95.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFeatures",
                columns: new[] { "Id", "Icon", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "service-icon-1.png", "Free shipping on all order", "FREE SHIPPING" },
                    { 2, "service-icon-2.png", "Online support 24 hours a day", "ONLINE SUPPORT" },
                    { 3, "service-icon-3.png", "Back guarantee under 5 days", "MONEY RETURN" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", "slider-1.jpg", "Best Selling!", "Top Collection" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidid", "slider-2.jpg", "Best Selling!", "Top Collection" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ServiceFeatures");

            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
