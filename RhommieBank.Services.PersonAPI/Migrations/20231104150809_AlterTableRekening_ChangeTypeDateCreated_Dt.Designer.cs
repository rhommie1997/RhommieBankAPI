﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RhommieBank.Services.PersonAPI.Data;

#nullable disable

namespace RhommieBank.Services.PersonAPI.Migrations
{
    [DbContext(typeof(RhommieBankDbContext))]
    [Migration("20231104150809_AlterTableRekening_ChangeTypeDateCreated_Dt")]
    partial class AlterTableRekening_ChangeTypeDateCreated_Dt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Bank", b =>
                {
                    b.Property<string>("BankCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankCode");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            BankCode = "014",
                            BankName = "BCA"
                        },
                        new
                        {
                            BankCode = "002",
                            BankName = "BRI"
                        },
                        new
                        {
                            BankCode = "008",
                            BankName = "Bank Mandiri"
                        },
                        new
                        {
                            BankCode = "009",
                            BankName = "BNI"
                        });
                });

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_dt")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            id = 1,
                            age = 22,
                            created_by = "System",
                            created_dt = new DateTime(2023, 11, 4, 22, 8, 9, 1, DateTimeKind.Local).AddTicks(8353),
                            name = "Erling Haaland"
                        },
                        new
                        {
                            id = 2,
                            age = 24,
                            created_by = "System",
                            created_dt = new DateTime(2023, 11, 4, 22, 8, 9, 1, DateTimeKind.Local).AddTicks(8380),
                            name = "Kylian Mbappe"
                        });
                });

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Rekening", b =>
                {
                    b.Property<string>("no_rekening")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("created_dt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isAccess")
                        .HasColumnType("bit");

                    b.Property<int>("person_id")
                        .HasColumnType("int");

                    b.Property<decimal>("saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("no_rekening");

                    b.HasIndex("BankCode");

                    b.HasIndex("person_id");

                    b.ToTable("Rekening");
                });

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Rekening", b =>
                {
                    b.HasOne("RhommieBank.Services.PersonAPI.Models.Bank", "Bank")
                        .WithMany("Rekenings")
                        .HasForeignKey("BankCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RhommieBank.Services.PersonAPI.Models.Person", "Person")
                        .WithMany("Rekenings")
                        .HasForeignKey("person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Bank", b =>
                {
                    b.Navigation("Rekenings");
                });

            modelBuilder.Entity("RhommieBank.Services.PersonAPI.Models.Person", b =>
                {
                    b.Navigation("Rekenings");
                });
#pragma warning restore 612, 618
        }
    }
}
