﻿// <auto-generated />
using CouponAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CouponAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241017095334_SeedCoupons")]
    partial class SeedCoupons
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CouponAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponID"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CouponID");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CouponID = 1,
                            CouponCode = "WELCOME",
                            DiscountAmount = 10.0,
                            MinAmount = 20
                        },
                        new
                        {
                            CouponID = 2,
                            CouponCode = "TRY NEW",
                            DiscountAmount = 20.0,
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
