// <auto-generated />
using BleApi.Categories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BleApi.Categories.Migrations
{
    [DbContext(typeof(CategoriesDbContext))]
    [Migration("20220914160107_CategoriesMigrations")]
    partial class CategoriesMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("BleApi.Categories.Model.Categories", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("product_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
