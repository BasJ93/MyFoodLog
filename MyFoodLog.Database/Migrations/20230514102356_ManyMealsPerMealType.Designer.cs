﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFoodLog.Database;

#nullable disable

namespace MyFoodLog.Database.Migrations
{
    [DbContext(typeof(MyFoodLogDbContext))]
    [Migration("20230514102356_ManyMealsPerMealType")]
    partial class ManyMealsPerMealType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("MyFoodLog.Database.Models.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Carbohydrates")
                        .HasPrecision(4)
                        .HasColumnType("TEXT");

                    b.Property<long?>("EAN13")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Energy")
                        .HasPrecision(4)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Fat")
                        .HasPrecision(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Protein")
                        .HasPrecision(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("QuantityUnit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK_FoodItems");

                    b.ToTable("FoodItems", (string)null);
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.FoodItemConsumption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasPrecision(2)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FoodItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MealId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId")
                        .IsUnique();

                    b.HasIndex("MealId");

                    b.ToTable("FoodConsumption");
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MealTypeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MealTypeId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.MealType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.FoodItemConsumption", b =>
                {
                    b.HasOne("MyFoodLog.Database.Models.FoodItem", "FoodItem")
                        .WithOne()
                        .HasForeignKey("MyFoodLog.Database.Models.FoodItemConsumption", "FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FoodItemConsumption_FoodItem");

                    b.HasOne("MyFoodLog.Database.Models.Meal", "Meal")
                        .WithMany("ConsumedItems")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Meal_FoodItemConsumption");

                    b.Navigation("FoodItem");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.Meal", b =>
                {
                    b.HasOne("MyFoodLog.Database.Models.MealType", "MealType")
                        .WithMany()
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Meal_MealType");

                    b.Navigation("MealType");
                });

            modelBuilder.Entity("MyFoodLog.Database.Models.Meal", b =>
                {
                    b.Navigation("ConsumedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
