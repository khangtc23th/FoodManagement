using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wed.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Intro = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Authorized",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorized", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorized_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Authorized_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4"), new Guid("11336570-9607-4634-8244-207e19971e98"), new DateTime(2026, 7, 26, 9, 20, 2, 525, DateTimeKind.Local).AddTicks(5435), null, null, "Root", null });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), "Quản trị viên" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("18015973-694b-4959-9e6f-0f4e24e3985b"), new Guid("11336570-9607-4634-8244-207e19971e98"), new DateTime(2026, 7, 26, 9, 20, 2, 525, DateTimeKind.Local).AddTicks(6131), null, null, "Product", new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4") },
                    { new Guid("647dced7-e87d-4ec8-9702-2c5281e77911"), new Guid("11336570-9607-4634-8244-207e19971e98"), new DateTime(2026, 7, 26, 9, 20, 2, 525, DateTimeKind.Local).AddTicks(5808), null, null, "Authorized", new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4") },
                    { new Guid("f46aa2d3-f286-41a1-86da-592f0f17e2fc"), new Guid("11336570-9607-4634-8244-207e19971e98"), new DateTime(2026, 7, 26, 9, 20, 2, 525, DateTimeKind.Local).AddTicks(6125), null, null, "Article", new Guid("f053ba68-398a-4019-87a1-5bc9466e9fe4") }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "GroupId", "LastLogin", "LoginName", "ModifiedBy", "ModifiedOn", "Name", "Password", "Picture" },
                values: new object[] { new Guid("11336570-9607-4634-8244-207e19971e98"), null, new DateTime(2026, 7, 26, 9, 20, 2, 522, DateTimeKind.Local).AddTicks(2676), "khangtc.23th@sv.dla.edu.vn", new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), null, "khang", null, null, "Tống Chí Khang", "c4ca4238a0b923820dcc509a6f75849b", "/img/users/TongKhang.jpg" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"), new Guid("11336570-9607-4634-8244-207e19971e98"), new DateTime(2026, 7, 26, 9, 20, 2, 525, DateTimeKind.Local).AddTicks(6089), null, null, "Nhóm quyền", new Guid("647dced7-e87d-4ec8-9702-2c5281e77911") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CategoryId", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("442979c9-9c96-42af-afde-0be7c02135e7"), new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"), "delete-group", "Xóa" },
                    { new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458"), new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"), "view-groups", "Xem danh sách" },
                    { new Guid("ab095bc1-31af-4b00-9fc5-e4e6f0f1121c"), new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"), "edit-group", "Cập nhật" },
                    { new Guid("dbb49494-3cca-4357-89c1-e954ddc2d4b3"), new Guid("3bcd9c68-1b73-44c9-aba7-d167b98cfe54"), "save-group", "Lưu" }
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("c39f1fa4-de2e-44a1-ae4b-ff80a61af108"), new Guid("164eadac-199a-4db7-bbc3-81b6254767b9"), new Guid("76d93c1d-3457-4624-8d6a-8a8d3b780458") });

            migrationBuilder.CreateIndex(
                name: "IX_Authorized_GroupId",
                table: "Authorized",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Authorized_RoleId",
                table: "Authorized",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_GroupId",
                table: "Member",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CategoryId",
                table: "Role",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Authorized");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
