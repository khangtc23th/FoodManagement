using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wed.Migrations
{
    /// <inheritdoc />
    public partial class s4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("4ce01ca4-68e2-48df-96b5-0997002b51fb"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("1f40cd6e-91f7-4c2f-a5b2-207698e2ffa0"));

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("4ce01ca4-68e2-48df-96b5-0997002b51fb"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 388, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 388, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 388, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 388, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 388, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("11336570-9607-4634-8244-207e19971e98"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 16, 3, 38, 387, DateTimeKind.Local).AddTicks(5391));
        }
    }
}
