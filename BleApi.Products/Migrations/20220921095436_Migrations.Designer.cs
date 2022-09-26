﻿// <auto-generated />
using System;
using BleApi.Products.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BleApi.Products.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20220921095436_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("BleApi.Products.Model.Products", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("category_id")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("product_image")
                        .HasColumnType("BLOB");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("product_price")
                        .HasColumnType("REAL");

                    b.Property<int>("product_stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("provider_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("product_id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
