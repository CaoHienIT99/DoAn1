    using DA1.Models;
using DA1.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DataContext()
        {

        }

        public DbSet<CategoryProduct> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsDetail> NewsDetails{ get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ProductToCart> ProductToCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); builder.Entity<OrderDetail>()
                .HasKey(c => new { c.OrderId, c.ProductId });
            base.OnModelCreating(builder); builder.Entity<CategoryProduct>().HasData(
                 new CategoryProduct()
                 {
                     CategoryID = 1,
                     CategoryName = "Aventador"
                 },
                 new CategoryProduct()
                 {
                     CategoryID = 2,
                     CategoryName = "Huracan"
                 },
                 new CategoryProduct()
                 {
                     CategoryID = 3,
                     CategoryName = "Urus"
                 },
                 new CategoryProduct()
                 {
                     CategoryID = 4,
                     CategoryName = "Limited Series"
                 });
            builder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                ProductName = "Aventador S",
                ProductImage = "aventador-s.jpg",
                ProductQuantity = 20,
                ProductPrice = 418000.00,
                Discount = 0,
                CreateDate = DateTime.Now,
                CategoryId = 1

            },
            new Product()
            {
                ProductId = 2,
                ProductName = "Huracan Evo",
                ProductImage = "Huracan-Evo.jpg",
                ProductQuantity = 16,
                ProductPrice = 13000.00,
                Discount = 0,
                CreateDate = DateTime.Now,
                CategoryId = 2

            },
             new Product()
             {
                 ProductId = 3,
                 ProductName = "Urus ST-X",
                 ProductImage = "urus.jpg",
                 ProductQuantity = 17,
                 ProductPrice = 15000.00,
                 Discount = 10,
                 CreateDate = DateTime.Now,
                 CategoryId = 3

             });

            builder.Entity<Role>().HasData(
                new Role()
                {
                    RoleID =1,
                    RoleName= "Admin"
                },
                new Role()
                {
                    RoleID = 2,
                    RoleName = "Customer"
                }
            );
            builder.Entity<User>().HasData(
                new User()
                {
                    UserID=1,
                    Username="Shop",
                    pass= "1234",
                    Fullname="Cao Trịnh Thu Hiền",
                    Adress="Tân Bình, TPHCM",
                    Email = "caohiendev01@gmail.com",
                    Phone= "0962656815",
                    Position= "Hoat dong",

                }
            );
            builder.Entity<Supplier>().HasData(
               new Supplier()
               {
                   SupplierID= 1,
                   SupplierName = "US",
                   Adress = "21 DC, Washington, US",
                   Email = "hainam.huflit@gmail.com",
                   PhoneNumber= 0962656815
               }
           );
            builder.Entity<ProductDetail>().HasData(
                new ProductDetail()
                {
                    ProductIdDetail= 1,
                    Description = "New 100%",
                    Displacement= "6.498 cm³ (396.5 cu in)",
                    Maxpower = "740 CV (544 kW) 8.400 rpm",
                    Topspeed = "350 km/h (217 mph)",
                    TAcceleration = "2,9 s",
                    Invented = "2020",
                    ProductId = 1,
                    SupplierID = 1                 
                }
            );
        }
        public DbSet<DA1.Models.Domain.ProductToCart> ProductToCart { get; set; }
    }
}
