using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 147m },
                    { 73, "Description for product 73", "Product 73", 848m },
                    { 72, "Description for product 72", "Product 72", 666m },
                    { 71, "Description for product 71", "Product 71", 396m },
                    { 70, "Description for product 70", "Product 70", 887m },
                    { 69, "Description for product 69", "Product 69", 661m },
                    { 68, "Description for product 68", "Product 68", 906m },
                    { 67, "Description for product 67", "Product 67", 802m },
                    { 66, "Description for product 66", "Product 66", 858m },
                    { 65, "Description for product 65", "Product 65", 641m },
                    { 64, "Description for product 64", "Product 64", 854m },
                    { 63, "Description for product 63", "Product 63", 978m },
                    { 62, "Description for product 62", "Product 62", 477m },
                    { 61, "Description for product 61", "Product 61", 458m },
                    { 60, "Description for product 60", "Product 60", 983m },
                    { 59, "Description for product 59", "Product 59", 954m },
                    { 58, "Description for product 58", "Product 58", 704m },
                    { 57, "Description for product 57", "Product 57", 827m },
                    { 56, "Description for product 56", "Product 56", 749m },
                    { 55, "Description for product 55", "Product 55", 269m },
                    { 54, "Description for product 54", "Product 54", 285m },
                    { 53, "Description for product 53", "Product 53", 591m },
                    { 74, "Description for product 74", "Product 74", 569m },
                    { 52, "Description for product 52", "Product 52", 267m },
                    { 75, "Description for product 75", "Product 75", 296m },
                    { 77, "Description for product 77", "Product 77", 558m },
                    { 98, "Description for product 98", "Product 98", 986m },
                    { 97, "Description for product 97", "Product 97", 224m },
                    { 96, "Description for product 96", "Product 96", 501m },
                    { 95, "Description for product 95", "Product 95", 422m },
                    { 94, "Description for product 94", "Product 94", 849m },
                    { 93, "Description for product 93", "Product 93", 946m },
                    { 92, "Description for product 92", "Product 92", 980m },
                    { 91, "Description for product 91", "Product 91", 565m },
                    { 90, "Description for product 90", "Product 90", 761m },
                    { 89, "Description for product 89", "Product 89", 574m },
                    { 88, "Description for product 88", "Product 88", 773m },
                    { 87, "Description for product 87", "Product 87", 289m },
                    { 86, "Description for product 86", "Product 86", 547m },
                    { 85, "Description for product 85", "Product 85", 540m },
                    { 84, "Description for product 84", "Product 84", 501m },
                    { 83, "Description for product 83", "Product 83", 494m },
                    { 82, "Description for product 82", "Product 82", 828m },
                    { 81, "Description for product 81", "Product 81", 916m },
                    { 80, "Description for product 80", "Product 80", 772m },
                    { 79, "Description for product 79", "Product 79", 291m },
                    { 78, "Description for product 78", "Product 78", 453m },
                    { 76, "Description for product 76", "Product 76", 654m },
                    { 51, "Description for product 51", "Product 51", 717m },
                    { 50, "Description for product 50", "Product 50", 279m },
                    { 49, "Description for product 49", "Product 49", 928m },
                    { 22, "Description for product 22", "Product 22", 398m },
                    { 21, "Description for product 21", "Product 21", 757m },
                    { 20, "Description for product 20", "Product 20", 174m },
                    { 19, "Description for product 19", "Product 19", 350m },
                    { 18, "Description for product 18", "Product 18", 681m },
                    { 17, "Description for product 17", "Product 17", 567m },
                    { 16, "Description for product 16", "Product 16", 981m },
                    { 15, "Description for product 15", "Product 15", 280m },
                    { 14, "Description for product 14", "Product 14", 172m },
                    { 13, "Description for product 13", "Product 13", 651m },
                    { 12, "Description for product 12", "Product 12", 760m },
                    { 11, "Description for product 11", "Product 11", 640m },
                    { 10, "Description for product 10", "Product 10", 356m },
                    { 9, "Description for product 9", "Product 9", 112m },
                    { 8, "Description for product 8", "Product 8", 659m },
                    { 7, "Description for product 7", "Product 7", 800m },
                    { 6, "Description for product 6", "Product 6", 345m },
                    { 5, "Description for product 5", "Product 5", 640m },
                    { 4, "Description for product 4", "Product 4", 941m },
                    { 3, "Description for product 3", "Product 3", 518m },
                    { 2, "Description for product 2", "Product 2", 699m },
                    { 23, "Description for product 23", "Product 23", 872m },
                    { 24, "Description for product 24", "Product 24", 814m },
                    { 25, "Description for product 25", "Product 25", 987m },
                    { 26, "Description for product 26", "Product 26", 657m },
                    { 48, "Description for product 48", "Product 48", 158m },
                    { 47, "Description for product 47", "Product 47", 741m },
                    { 46, "Description for product 46", "Product 46", 315m },
                    { 45, "Description for product 45", "Product 45", 623m },
                    { 44, "Description for product 44", "Product 44", 519m },
                    { 43, "Description for product 43", "Product 43", 840m },
                    { 42, "Description for product 42", "Product 42", 202m },
                    { 41, "Description for product 41", "Product 41", 878m },
                    { 40, "Description for product 40", "Product 40", 781m },
                    { 39, "Description for product 39", "Product 39", 832m },
                    { 99, "Description for product 99", "Product 99", 877m },
                    { 38, "Description for product 38", "Product 38", 901m },
                    { 36, "Description for product 36", "Product 36", 393m },
                    { 35, "Description for product 35", "Product 35", 511m },
                    { 34, "Description for product 34", "Product 34", 744m },
                    { 33, "Description for product 33", "Product 33", 958m },
                    { 32, "Description for product 32", "Product 32", 781m },
                    { 31, "Description for product 31", "Product 31", 715m },
                    { 30, "Description for product 30", "Product 30", 257m },
                    { 29, "Description for product 29", "Product 29", 681m },
                    { 28, "Description for product 28", "Product 28", 423m },
                    { 27, "Description for product 27", "Product 27", 887m },
                    { 37, "Description for product 37", "Product 37", 684m },
                    { 100, "Description for product 100", "Product 100", 764m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 7 },
                    { 73, 73, 4 },
                    { 72, 72, 6 },
                    { 71, 71, 18 },
                    { 70, 70, 13 },
                    { 69, 69, 12 },
                    { 68, 68, 2 },
                    { 67, 67, 0 },
                    { 66, 66, 3 },
                    { 65, 65, 0 },
                    { 64, 64, 5 },
                    { 63, 63, 1 },
                    { 62, 62, 18 },
                    { 61, 61, 6 },
                    { 60, 60, 13 },
                    { 59, 59, 15 },
                    { 58, 58, 13 },
                    { 57, 57, 6 },
                    { 56, 56, 12 },
                    { 55, 55, 7 },
                    { 54, 54, 5 },
                    { 53, 53, 13 },
                    { 74, 74, 0 },
                    { 52, 52, 3 },
                    { 75, 75, 8 },
                    { 77, 77, 11 },
                    { 98, 98, 18 },
                    { 97, 97, 12 },
                    { 96, 96, 5 },
                    { 95, 95, 9 },
                    { 94, 94, 16 },
                    { 93, 93, 6 },
                    { 92, 92, 8 },
                    { 91, 91, 1 },
                    { 90, 90, 9 },
                    { 89, 89, 13 },
                    { 88, 88, 6 },
                    { 87, 87, 17 },
                    { 86, 86, 7 },
                    { 85, 85, 18 },
                    { 84, 84, 17 },
                    { 83, 83, 13 },
                    { 82, 82, 16 },
                    { 81, 81, 15 },
                    { 80, 80, 18 },
                    { 79, 79, 10 },
                    { 78, 78, 1 },
                    { 76, 76, 1 },
                    { 51, 51, 6 },
                    { 50, 50, 19 },
                    { 49, 49, 11 },
                    { 22, 22, 14 },
                    { 21, 21, 16 },
                    { 20, 20, 12 },
                    { 19, 19, 16 },
                    { 18, 18, 14 },
                    { 17, 17, 8 },
                    { 16, 16, 0 },
                    { 15, 15, 1 },
                    { 14, 14, 14 },
                    { 13, 13, 3 },
                    { 12, 12, 13 },
                    { 11, 11, 14 },
                    { 10, 10, 12 },
                    { 9, 9, 10 },
                    { 8, 8, 18 },
                    { 7, 7, 3 },
                    { 6, 6, 10 },
                    { 5, 5, 9 },
                    { 4, 4, 18 },
                    { 3, 3, 4 },
                    { 2, 2, 14 },
                    { 23, 23, 8 },
                    { 24, 24, 11 },
                    { 25, 25, 2 },
                    { 26, 26, 15 },
                    { 48, 48, 6 },
                    { 47, 47, 19 },
                    { 46, 46, 4 },
                    { 45, 45, 0 },
                    { 44, 44, 6 },
                    { 43, 43, 3 },
                    { 42, 42, 14 },
                    { 41, 41, 4 },
                    { 40, 40, 16 },
                    { 39, 39, 9 },
                    { 99, 99, 5 },
                    { 38, 38, 2 },
                    { 36, 36, 7 },
                    { 35, 35, 1 },
                    { 34, 34, 1 },
                    { 33, 33, 12 },
                    { 32, 32, 11 },
                    { 31, 31, 11 },
                    { 30, 30, 5 },
                    { 29, 29, 16 },
                    { 28, 28, 5 },
                    { 27, 27, 3 },
                    { 37, 37, 1 },
                    { 100, 100, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
