using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wed.Migrations
{
    /// <inheritdoc />
    public partial class s5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("1f40cd6e-91f7-4c2f-a5b2-207698e2ffa0"));

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Details_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("d64279ff-ffd7-4f88-8744-aadf57fc7234"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 297, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 297, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 297, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 297, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 297, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("11336570-9607-4634-8244-207e19971e98"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 34, 45, 295, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.CreateIndex(
                name: "IX_Details_OrderId",
                table: "Details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId",
                table: "Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("d64279ff-ffd7-4f88-8744-aadf57fc7234"));

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("1f40cd6e-91f7-4c2f-a5b2-207698e2ffa0"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 321, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 321, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 320, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 320, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 321, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("11336570-9607-4634-8244-207e19971e98"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 9, 1, 319, DateTimeKind.Local).AddTicks(8350));
        }
    }
}
