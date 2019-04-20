﻿// <auto-generated />
using System;
using AspnetRun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspnetRun.Infrastructure.Migrations
{
    [DbContext(typeof(AspnetRunContext))]
    [Migration("20190417123937_Initial_Aspnetrun_RealWorld")]
    partial class Initial_Aspnetrun_RealWorld
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.aspnetrun_type_hilo", "'aspnetrun_type_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetRun.Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("CompanyName");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CustomerId");

                    b.Property<decimal?>("Freight");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.Property<int?>("ShipVia");

                    b.Property<DateTimeOffset?>("ShippedDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<float>("Discount");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<short>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int?>("BrandId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<bool>("Discontinued");

                    b.Property<string>("PictureUri");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("QuantityPerUnit");

                    b.Property<short?>("ReorderLevel");

                    b.Property<int?>("SupplierId");

                    b.Property<decimal?>("UnitPrice");

                    b.Property<short?>("UnitsInStock");

                    b.Property<short?>("UnitsOnOrder");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<decimal?>("Discount");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("ShoppingCartId");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Fax");

                    b.Property<string>("HomePage");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "aspnetrun_type_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("IdentityGuid");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Customer", b =>
                {
                    b.OwnsOne("AspnetRun.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId");

                            b1.Property<string>("AddressDesc");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("Region");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.HasOne("AspnetRun.Core.Entities.Customer")
                                .WithOne("Address")
                                .HasForeignKey("AspnetRun.Core.ValueObjects.Address", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Order", b =>
                {
                    b.HasOne("AspnetRun.Core.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("AspnetRun.Core.ValueObjects.Address", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId");

                            b1.Property<string>("AddressDesc");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("Region");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.HasOne("AspnetRun.Core.Entities.Order")
                                .WithOne("ShippingAddress")
                                .HasForeignKey("AspnetRun.Core.ValueObjects.Address", "OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("AspnetRun.Core.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspnetRun.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Product", b =>
                {
                    b.HasOne("AspnetRun.Core.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("AspnetRun.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("AspnetRun.Core.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("AspnetRun.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspnetRun.Core.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.Supplier", b =>
                {
                    b.OwnsOne("AspnetRun.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("SupplierId");

                            b1.Property<string>("AddressDesc");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("Region");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.HasOne("AspnetRun.Core.Entities.Supplier")
                                .WithOne("Address")
                                .HasForeignKey("AspnetRun.Core.ValueObjects.Address", "SupplierId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AspnetRun.Core.Entities.User", b =>
                {
                    b.OwnsOne("AspnetRun.Core.ValueObjects.AdAccount", "AdAccount", b1 =>
                        {
                            b1.Property<int>("UserId");

                            b1.Property<string>("Domain");

                            b1.Property<string>("Name");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.HasOne("AspnetRun.Core.Entities.User")
                                .WithOne("AdAccount")
                                .HasForeignKey("AspnetRun.Core.ValueObjects.AdAccount", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
