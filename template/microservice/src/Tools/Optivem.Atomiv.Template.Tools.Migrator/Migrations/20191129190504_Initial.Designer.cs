﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Optivem.Atomiv.Template.Tools.Migrator.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191129190504_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.CustomerRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderItemRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("StatusId")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StatusId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderItemStatusRecord", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("OrderItemStatuses");

                    b.HasData(
                        new
                        {
                            Id = (byte)0,
                            Code = "None"
                        },
                        new
                        {
                            Id = (byte)1,
                            Code = "Allocated"
                        },
                        new
                        {
                            Id = (byte)2,
                            Code = "Invoiced"
                        },
                        new
                        {
                            Id = (byte)3,
                            Code = "Shipped"
                        },
                        new
                        {
                            Id = (byte)4,
                            Code = "OnOrder"
                        },
                        new
                        {
                            Id = (byte)5,
                            Code = "NoStock"
                        });
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("OrderStatusId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderStatusRecord", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = (byte)0,
                            Code = "None"
                        },
                        new
                        {
                            Id = (byte)1,
                            Code = "New"
                        },
                        new
                        {
                            Id = (byte)2,
                            Code = "Invoiced"
                        },
                        new
                        {
                            Id = (byte)3,
                            Code = "Shipped"
                        },
                        new
                        {
                            Id = (byte)4,
                            Code = "Closed"
                        },
                        new
                        {
                            Id = (byte)7,
                            Code = "Submitted"
                        },
                        new
                        {
                            Id = (byte)8,
                            Code = "Cancelled"
                        },
                        new
                        {
                            Id = (byte)9,
                            Code = "Archived"
                        });
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.ProductRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsListed")
                        .HasColumnType("bit");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderItemRecord", b =>
                {
                    b.HasOne("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderRecord", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.ProductRecord", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderItemStatusRecord", "Status")
                        .WithMany("OrderItems")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderRecord", b =>
                {
                    b.HasOne("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.CustomerRecord", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records.OrderStatusRecord", "OrderStatus")
                        .WithMany("OrderRecords")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
