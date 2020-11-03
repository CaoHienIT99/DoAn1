﻿// <auto-generated />
using System;
using DA1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DA1.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DA1.Models.Domain.CategoryProduct", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Aventador"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Huracan"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Urus"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Limited Series"
                        });
                });

            modelBuilder.Entity("DA1.Models.Domain.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NewsImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sub_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("DA1.Models.Domain.NewsDetail", b =>
                {
                    b.Property<int>("NewsDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nameposted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsID")
                        .HasColumnType("int");

                    b.HasKey("NewsDetailID");

                    b.HasIndex("NewsID");

                    b.ToTable("NewsDetails");
                });

            modelBuilder.Entity("DA1.Models.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DA1.Models.Domain.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DA1.Models.Domain.ProductToCart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductToCart");
                });

            modelBuilder.Entity("DA1.Models.Domain.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Customer"
                        });
                });

            modelBuilder.Entity("DA1.Models.Domain.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierID = 1,
                            Adress = "21 DC, Washington, US",
                            Email = "hainam.huflit@gmail.com",
                            PhoneNumber = 962656815,
                            SupplierName = "US"
                        });
                });

            modelBuilder.Entity("DA1.Models.Domain.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Adress = "Tân Bình, TPHCM",
                            Email = "caohiendev01@gmail.com",
                            Fullname = "Cao Trịnh Thu Hiền",
                            Phone = "0962656815",
                            Position = "Hoat dong",
                            Username = "Shop",
                            pass = "1234"
                        });
                });

            modelBuilder.Entity("DA1.Models.Domain.UserRole", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID1")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID1");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DA1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2020, 7, 18, 20, 28, 21, 37, DateTimeKind.Local).AddTicks(1676),
                            Discount = 0,
                            ProductImage = "aventador-s.jpg",
                            ProductName = "Aventador S",
                            ProductPrice = 418000.0,
                            ProductQuantity = 20
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            CreateDate = new DateTime(2020, 7, 18, 20, 28, 21, 38, DateTimeKind.Local).AddTicks(8317),
                            Discount = 0,
                            ProductImage = "Huracan-Evo.jpg",
                            ProductName = "Huracan Evo",
                            ProductPrice = 13000.0,
                            ProductQuantity = 16
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            CreateDate = new DateTime(2020, 7, 18, 20, 28, 21, 38, DateTimeKind.Local).AddTicks(8350),
                            Discount = 10,
                            ProductImage = "urus.jpg",
                            ProductName = "Urus ST-X",
                            ProductPrice = 15000.0,
                            ProductQuantity = 17
                        });
                });

            modelBuilder.Entity("DA1.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductIdDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Displacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Invented")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maxpower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("TAcceleration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topspeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductIdDetail");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierID");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            ProductIdDetail = 1,
                            Description = "New 100%",
                            Displacement = "6.498 cm³ (396.5 cu in)",
                            Invented = "2020",
                            Maxpower = "740 CV (544 kW) 8.400 rpm",
                            ProductId = 1,
                            SupplierID = 1,
                            TAcceleration = "2,9 s",
                            Topspeed = "350 km/h (217 mph)"
                        });
                });

            modelBuilder.Entity("DA1.Models.Domain.NewsDetail", b =>
                {
                    b.HasOne("DA1.Models.Domain.News", "News")
                        .WithMany()
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DA1.Models.Domain.OrderDetail", b =>
                {
                    b.HasOne("DA1.Models.Domain.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DA1.Models.Domain.ProductToCart", b =>
                {
                    b.HasOne("DA1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("DA1.Models.Domain.UserRole", b =>
                {
                    b.HasOne("DA1.Models.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA1.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID1");
                });

            modelBuilder.Entity("DA1.Models.Product", b =>
                {
                    b.HasOne("DA1.Models.Domain.CategoryProduct", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DA1.Models.ProductDetail", b =>
                {
                    b.HasOne("DA1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA1.Models.Domain.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
