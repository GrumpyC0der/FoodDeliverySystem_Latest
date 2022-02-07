﻿// <auto-generated />
using System;
using FoodDeliverySystem.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDeliverySystem.Server.Migrations
{
    [DbContext(typeof(FoodDeliveryDbContext))]
    [Migration("20220207000245_ddd")]
    partial class ddd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodStoresID")
                        .HasColumnType("int");

                    b.HasKey("FoodID");

                    b.HasIndex("FoodStoresID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.FoodStores", b =>
                {
                    b.Property<int>("FoodStoresID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FoodQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodStoresID");

                    b.ToTable("FoodStores");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("FoodID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("OrderQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderItemsId");

                    b.HasIndex("FoodID");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StaffContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffPostion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cellnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emailid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Food", b =>
                {
                    b.HasOne("FoodDeliverySystem.Shared.Models.FoodStores", "FoodStores")
                        .WithMany("Foods")
                        .HasForeignKey("FoodStoresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodStores");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Order", b =>
                {
                    b.HasOne("FoodDeliverySystem.Shared.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("FoodDeliverySystem.Shared.Models.Staff", "Staff")
                        .WithMany("Order")
                        .HasForeignKey("StaffId");

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.OrderItems", b =>
                {
                    b.HasOne("FoodDeliverySystem.Shared.Models.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodID");

                    b.HasOne("FoodDeliverySystem.Shared.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Food");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Payment", b =>
                {
                    b.HasOne("FoodDeliverySystem.Shared.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Food", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.FoodStores", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("FoodDeliverySystem.Shared.Models.Staff", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
