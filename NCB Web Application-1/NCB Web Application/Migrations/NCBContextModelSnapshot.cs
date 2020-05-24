﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NCB_Web_Application.Models;

namespace NCB_Web_Application.Migrations
{
    [DbContext(typeof(NCBContext))]
    partial class NCBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NCB_Web_Application.Models.Customer", b =>
                {
                    b.Property<int>("custId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccType")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(40)");

                    b.HasKey("custId");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}