﻿// <auto-generated />
using System;
using FincoraConsoleAppDemo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FincoraConsoleAppDemo.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20240503182027_addingAtribs2")]
    partial class addingAtribs2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ContractTypeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InsuranceCompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Active");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContractTypeId");

                    b.HasIndex("InsuranceCompanyId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.ContractType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("InvolveVehicle")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ContractTypes");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.InsuranceCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EvidenceNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GearboxType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EvidenceNumber")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Client", b =>
                {
                    b.HasOne("FincoraConsoleAppDemo.Models.Address", "Address")
                        .WithMany("Clients")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Contract", b =>
                {
                    b.HasOne("FincoraConsoleAppDemo.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FincoraConsoleAppDemo.Models.ContractType", "ContractType")
                        .WithMany("Contracts")
                        .HasForeignKey("ContractTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FincoraConsoleAppDemo.Models.InsuranceCompany", "InsuranceCompany")
                        .WithMany("Contracts")
                        .HasForeignKey("InsuranceCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FincoraConsoleAppDemo.Models.Vehicle", "Vehicle")
                        .WithMany("Contracts")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Client");

                    b.Navigation("ContractType");

                    b.Navigation("InsuranceCompany");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.InsuranceCompany", b =>
                {
                    b.HasOne("FincoraConsoleAppDemo.Models.Address", "Address")
                        .WithMany("InsuranceCompanys")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Address", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("InsuranceCompanys");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.ContractType", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.InsuranceCompany", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("FincoraConsoleAppDemo.Models.Vehicle", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
