using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wed.Migrations
{
    /// <inheritdoc />
    public partial class s7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("6c1706f5-0b41-437d-994f-250920463ff8"));

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("01aa570c-dc1e-45fe-94bb-e0822f55ffd1"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 219, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 219, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 219, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 219, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 219, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("11336570-9607-4634-8244-207e19971e98"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 20, 22, 56, 218, DateTimeKind.Local).AddTicks(3963));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("01aa570c-dc1e-45fe-94bb-e0822f55ffd1"));

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("6c1706f5-0b41-437d-994f-250920463ff8"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 512, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 512, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 512, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 512, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 512, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("11336570-9607-4634-8244-207e19971e98"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 26, 19, 46, 4, 511, DateTimeKind.Local).AddTicks(1231));
        }
    }
}
