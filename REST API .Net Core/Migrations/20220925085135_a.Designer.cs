﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_API_.Net_Core.DbContexts;

#nullable disable

namespace REST_API_.Net_Core.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220925085135_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("REST_API_.Net_Core.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            ID = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Name = "First Category"
                        });
                });

            modelBuilder.Entity("REST_API_.Net_Core.Entities.Products", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CateogryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CateogryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            CateogryID = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            ImgURL = "D:/Monthly Tasks/Building REST API using .Net Core/REST API .Net Core/Images/Bitmap.png",
                            Name = "First Product",
                            Price = 1m,
                            Quantity = 1m
                        },
                        new
                        {
                            ID = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            CateogryID = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            ImgURL = "D:/Monthly Tasks/Building REST API using .Net Core/REST API .Net Core/Images/shutterstock_662279290.png",
                            Name = "Second Product",
                            Price = 1m,
                            Quantity = 1m
                        });
                });

            modelBuilder.Entity("REST_API_.Net_Core.Entities.Products", b =>
                {
                    b.HasOne("REST_API_.Net_Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CateogryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("REST_API_.Net_Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
