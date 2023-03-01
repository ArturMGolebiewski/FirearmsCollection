﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.Infrastructure.Database;

#nullable disable

namespace MyAPI.Infrastructure.Migrations
{
    [DbContext(typeof(FirearmContext))]
    [Migration("20230301115935_AddingAmmunition")]
    partial class AddingAmmunition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Ammunition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CaliberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FirearmTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CaliberId");

                    b.HasIndex("FirearmTypeId");

                    b.ToTable("Ammunition");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Caliber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaliberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Calibers");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Firearm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CaliberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirearmModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FirearmTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CaliberId");

                    b.HasIndex("FirearmTypeId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Firearms");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.FirearmType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FirearmType");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfFounding")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Ammunition", b =>
                {
                    b.HasOne("MyAPI.Infrastructure.Database.Entities.Caliber", "Caliber")
                        .WithMany()
                        .HasForeignKey("CaliberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAPI.Infrastructure.Database.Entities.FirearmType", "FirearmType")
                        .WithMany()
                        .HasForeignKey("FirearmTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caliber");

                    b.Navigation("FirearmType");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Firearm", b =>
                {
                    b.HasOne("MyAPI.Infrastructure.Database.Entities.Caliber", "Caliber")
                        .WithMany()
                        .HasForeignKey("CaliberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAPI.Infrastructure.Database.Entities.FirearmType", "FirearmType")
                        .WithMany()
                        .HasForeignKey("FirearmTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyAPI.Infrastructure.Database.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Firearms")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caliber");

                    b.Navigation("FirearmType");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("MyAPI.Infrastructure.Database.Entities.Manufacturer", b =>
                {
                    b.Navigation("Firearms");
                });
#pragma warning restore 612, 618
        }
    }
}
