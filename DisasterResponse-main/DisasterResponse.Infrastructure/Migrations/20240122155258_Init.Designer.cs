﻿// <auto-generated />
using System;
using DisasterResponse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisasterResponse.Infrastructure.Migrations
{
    [DbContext(typeof(DisasterDbContext))]
    [Migration("20240122155258_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DisasterResponse.Domain.Aid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AidType")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.ToTable("Aids");
                });

            modelBuilder.Entity("DisasterResponse.Domain.AidRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("AmountProvided")
                        .HasColumnType("int");

                    b.Property<Guid>("IndividualAffectedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AidId");

                    b.HasIndex("IndividualAffectedId");

                    b.ToTable("AidRequests");
                });

            modelBuilder.Entity("DisasterResponse.Domain.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("DisasterResponse.Domain.Entities.IndividualAffected", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DamageCases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndividualsAffected");
                });

            modelBuilder.Entity("DisasterResponse.Domain.IncomeAid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AidId");

                    b.HasIndex("DonorId");

                    b.ToTable("IncomeAid");
                });

            modelBuilder.Entity("DisasterResponse.Domain.Aid", b =>
                {
                    b.HasOne("DisasterResponse.Domain.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("DisasterResponse.Domain.AidRequest", b =>
                {
                    b.HasOne("DisasterResponse.Domain.Aid", "Aid")
                        .WithMany("AidRequests")
                        .HasForeignKey("AidId");

                    b.HasOne("DisasterResponse.Domain.Entities.IndividualAffected", "IndividualAffected")
                        .WithMany()
                        .HasForeignKey("IndividualAffectedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aid");

                    b.Navigation("IndividualAffected");
                });

            modelBuilder.Entity("DisasterResponse.Domain.IncomeAid", b =>
                {
                    b.HasOne("DisasterResponse.Domain.Aid", "Aid")
                        .WithMany("IncomeAids")
                        .HasForeignKey("AidId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DisasterResponse.Domain.Donor", "Donor")
                        .WithMany("IncomeAids")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aid");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("DisasterResponse.Domain.Aid", b =>
                {
                    b.Navigation("AidRequests");

                    b.Navigation("IncomeAids");
                });

            modelBuilder.Entity("DisasterResponse.Domain.Donor", b =>
                {
                    b.Navigation("IncomeAids");
                });
#pragma warning restore 612, 618
        }
    }
}
