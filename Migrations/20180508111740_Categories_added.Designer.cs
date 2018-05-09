﻿// <auto-generated />
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookStore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180508111740_Categories_added")]
    partial class Categories_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Data.EntityModels.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookStore.Data.EntityModels.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int>("AuthorID");

                    b.Property<string>("Category");

                    b.Property<int>("CopiesAvailable");

                    b.Property<int>("CopiesSold");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<double>("Rating");

                    b.Property<string>("YearPublished");

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Data.EntityModels.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookID");

                    b.Property<string>("CartID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookStore.Data.EntityModels.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookStore.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<double>("Total");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookStore.Models.OrderDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookID");

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BookStore.Data.EntityModels.Cart", b =>
                {
                    b.HasOne("BookStore.Data.EntityModels.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStore.Models.OrderDetails", b =>
                {
                    b.HasOne("BookStore.Data.EntityModels.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStore.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
