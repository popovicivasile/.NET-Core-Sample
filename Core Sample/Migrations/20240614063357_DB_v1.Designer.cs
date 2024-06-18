﻿// <auto-generated />
using System;
using Core_Sample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core_Sample.Migrations
{
    [DbContext(typeof(ServiceContext))]
    [Migration("20240614063357_DB_v1")]
    partial class DB_v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core_Sample.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("maxMachines")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Core_Sample.Models.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<double?>("EngineHours")
                        .HasColumnType("float");

                    b.Property<string>("FuelType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MachineSerial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trademark")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Core_Sample.Models.MachinesAttirbute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long?>("Imei")
                        .HasColumnType("bigint")
                        .HasColumnName("imei");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("latitude");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("longitude");

                    b.Property<double?>("Speed")
                        .HasColumnType("float")
                        .HasColumnName("speed");

                    b.Property<double?>("Timestamp")
                        .HasColumnType("float")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.ToTable("MachinesAttirbutes");
                });

            modelBuilder.Entity("Core_Sample.Models.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Aditional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CabAirFilter")
                        .HasColumnType("bit");

                    b.Property<bool?>("EngineAirFilter")
                        .HasColumnType("bit");

                    b.Property<double?>("EngineHours")
                        .HasColumnType("float");

                    b.Property<int?>("EngineOilAmmount")
                        .HasColumnType("int");

                    b.Property<bool?>("FuelFilter")
                        .HasColumnType("bit");

                    b.Property<int?>("TransmisionOilAmmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Maintenance", (string)null);
                });

            modelBuilder.Entity("Core_Sample.Models.Machine", b =>
                {
                    b.HasOne("Core_Sample.Models.Account", "Account")
                        .WithMany("Machines")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Core_Sample.Models.Maintenance", b =>
                {
                    b.HasOne("Core_Sample.Models.Machine", "IdNavigation")
                        .WithOne("Maintenance")
                        .HasForeignKey("Core_Sample.Models.Maintenance", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Maintenance_Machines");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Core_Sample.Models.Account", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("Core_Sample.Models.Machine", b =>
                {
                    b.Navigation("Maintenance");
                });
#pragma warning restore 612, 618
        }
    }
}
