﻿// <auto-generated />
using System;
using FreshVegCart.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreshVegCart.API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<int>("UserAddressId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/avocado.png",
                            Name = "Avocado",
                            Price = 1.99m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/beet.png",
                            Name = "Beet",
                            Price = 0.99m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/bell_pepper.png",
                            Name = "Bell Pepper",
                            Price = 1.50m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/broccoli.png",
                            Name = "Broccoli",
                            Price = 2.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cabbage.png",
                            Name = "Cabbage",
                            Price = 1.20m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/capsicum.png",
                            Name = "Capsicum",
                            Price = 1.80m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/carrot.png",
                            Name = "Carrot",
                            Price = 0.80m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cauliflower.png",
                            Name = "Cauliflower",
                            Price = 2.50m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/coriander.png",
                            Name = "Coriander",
                            Price = 0.70m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/corn.png",
                            Name = "Corn",
                            Price = 1.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 11,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/cucumber.png",
                            Name = "Cucumber",
                            Price = 0.90m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 12,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/eggplant.png",
                            Name = "Eggplant",
                            Price = 1.75m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 13,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/farmer.png",
                            Name = "Farmer",
                            Price = 5.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 14,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ginger.png",
                            Name = "Ginger",
                            Price = 2.20m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 15,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/green_beans.png",
                            Name = "Green Beans",
                            Price = 1.60m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 16,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/ladyfinger.png",
                            Name = "Ladyfinger",
                            Price = 1.10m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 17,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/lettuce.png",
                            Name = "Lettuce",
                            Price = 1.30m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 18,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/mushroom.png",
                            Name = "Mushroom",
                            Price = 2.80m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 19,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/onion.png",
                            Name = "Onion",
                            Price = 0.60m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 20,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pea.png",
                            Name = "Pea",
                            Price = 1.40m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 21,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/potato.png",
                            Name = "Potato",
                            Price = 0.50m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 22,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/pumpkin.png",
                            Name = "Pumpkin",
                            Price = 3.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 23,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/radish.png",
                            Name = "Radish",
                            Price = 0.85m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 24,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/red_chili.png",
                            Name = "Red Chili",
                            Price = 1.50m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 25,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/spinach.png",
                            Name = "Spinach",
                            Price = 1.20m,
                            Unit = "bunch"
                        },
                        new
                        {
                            Id = 26,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/tomato.png",
                            Name = "Tomato",
                            Price = 0.95m,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 27,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/turnip.png",
                            Name = "Turnip",
                            Price = 0.75m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 28,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/vegetables.png",
                            Name = "Vegetables",
                            Price = 4.00m,
                            Unit = "each"
                        },
                        new
                        {
                            Id = 29,
                            ImageUrl = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/yellow_capsicum.png",
                            Name = "Yellow Capsicum",
                            Price = 1.80m,
                            Unit = "each"
                        });
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.Order", b =>
                {
                    b.HasOne("FreshVegCart.API.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("FreshVegCart.API.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.UserAddress", b =>
                {
                    b.HasOne("FreshVegCart.API.Data.Entities.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("FreshVegCart.API.Data.Entities.User", b =>
                {
                    b.Navigation("UserAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
