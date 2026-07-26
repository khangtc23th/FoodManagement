using Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace wed.Models.EF
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    Id = Guid.Parse("164EADAC-199A-4DB7-BBC3-81B6254767B9"),
                    Name = "Quản trị viên"
                }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member()
                {
                    Id = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    Name = "Tống Chí Khang",
                    Picture = "/img/users/TongKhang.jpg",
                    LoginName = "khang",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Email = "khangtc.23th@sv.dla.edu.vn",
                    CreatedOn = DateTime.Now,
                    GroupId = Guid.Parse("164EADAC-199A-4DB7-BBC3-81B6254767B9")
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("F053BA68-398A-4019-87A1-5BC9466E9FE4"),
                    Name = "Root",
                    CreatedBy = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    CreatedOn = DateTime.Now
                },
                new Category()
                {
                    Id = Guid.Parse("647DCED7-E87D-4EC8-9702-2C5281E77911"),
                    Name = "Authorized",
                    CreatedBy = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F053BA68-398A-4019-87A1-5BC9466E9FE4")
                },
                new Category()
                {
                    Id = Guid.Parse("3BCD9C68-1B73-44C9-ABA7-D167B98CFE54"),
                    Name = "Nhóm quyền",
                    CreatedBy = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("647DCED7-E87D-4EC8-9702-2C5281E77911")
                },
                new Category()
                {
                    Id = Guid.Parse("F46AA2D3-F286-41A1-86DA-592F0F17E2FC"),
                    Name = "Article",
                    CreatedBy = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F053BA68-398A-4019-87A1-5BC9466E9FE4")
                },
                new Category()
                {
                    Id = Guid.Parse("18015973-694B-4959-9E6F-0F4E24E3985B"),
                    Name = "Product",
                    CreatedBy = Guid.Parse("11336570-9607-4634-8244-207E19971E98"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F053BA68-398A-4019-87A1-5BC9466E9FE4")
                }
                );
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("76D93C1D-3457-4624-8D6A-8A8D3B780458"),
                    Name = "Xem danh sách",
                    Code = "view-group",
                    CategoryId = Guid.Parse("3BCD9C68-1B73-44C9-ABA7-D167B98CFE54")
                },
                    new Role()
                    {
                        Id = Guid.Parse("AB095BC1-31AF-4B00-9FC5-E4E6F0F1121C"),
                        Name = "Cập nhật",
                        Code = "edit-group",
                        CategoryId = Guid.Parse("3BCD9C68-1B73-44C9-ABA7-D167B98CFE54")
                    },
                    new Role()
                    {
                        Id = Guid.Parse("DBB49494-3CCA-4357-89C1-E954DDC2D4B3"),
                        Name = "Lưu",
                        Code = "save-group",
                        CategoryId = Guid.Parse("3BCD9C68-1B73-44C9-ABA7-D167B98CFE54")
                    },
                    new Role()
                    {
                        Id = Guid.Parse("442979C9-9C96-42AF-AFDE-0BE7C02135E7"),
                        Name = "Xóa",
                        Code = "delete-group",
                        CategoryId = Guid.Parse("3BCD9C68-1B73-44C9-ABA7-D167B98CFE54")
                    }
                );
            modelBuilder.Entity<Authorized>().HasData(
                new Authorized()
                {
                    Id = Guid.NewGuid(),
                    GroupId = Guid.Parse("164EADAC-199A-4DB7-BBC3-81B6254767B9"),
                    RoleId = Guid.Parse("76D93C1D-3457-4624-8D6A-8A8D3B780458")
                }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Authorized> Authorizeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Details> Details { get; set; } 
    }
}
