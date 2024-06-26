﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Task;

#nullable disable

namespace Test_Task.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test_Task.Models.ExcelFileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtmosphericPressure")
                        .HasColumnType("int");

                    b.Property<int?>("CloudCover")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<double?>("DewPoint")
                        .HasColumnType("float");

                    b.Property<double?>("HorizontalVisibility")
                        .HasColumnType("float");

                    b.Property<double?>("Humidity")
                        .HasColumnType("float");

                    b.Property<int?>("LowLimit")
                        .HasColumnType("int");

                    b.Property<TimeOnly?>("MoscowTime")
                        .HasColumnType("time");

                    b.Property<double?>("Temperature")
                        .HasColumnType("float");

                    b.Property<string>("WeatherPhenomena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WindDirection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WindSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExcelData");
                });
#pragma warning restore 612, 618
        }
    }
}
