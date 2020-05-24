﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NCB_Web_Application.Models;

namespace NCB_Web_Application.Migrations.NCBTeller
{
    [DbContext(typeof(NCBTellerContext))]
    partial class NCBTellerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NCB_Web_Application.Models.Teller", b =>
                {
                    b.Property<int>("TellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tellAddress")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("tellName")
                        .HasColumnType("varchar(40)");

                    b.HasKey("TellId");

                    b.ToTable("tellers");
                });
#pragma warning restore 612, 618
        }
    }
}
