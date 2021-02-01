﻿// <auto-generated />
using System;
using DB_RF_test_task.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB_RF_test_task.Repositories.Migrations
{
    [DbContext(typeof(CitizensContext))]
    partial class CitizensContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DB_RF_test_task.Repositories.Entities.CitizenEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("birth_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("cdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("death_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("first_name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("inn")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("last_name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("patronymic")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("snils")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("udate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Citizens");
                });
#pragma warning restore 612, 618
        }
    }
}
