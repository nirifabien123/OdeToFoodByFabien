﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdeToFoodByFabien.Context;

namespace OdeToFoodByFabien.Migrations
{
    [DbContext(typeof(FoodDbContext))]
    [Migration("20200127224207_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("OdeToFoodByFabien.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CuisineName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("FoodName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
