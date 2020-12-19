﻿// <auto-generated />
using System;
using CESystem.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CESystem.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20201217175154_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CESystem.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_date");

                    b.Property<string>("LastModified")
                        .HasColumnType("text")
                        .HasColumnName("last_modified");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("CESystem.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Commission")
                        .HasColumnType("text")
                        .HasColumnName("commission");

                    b.Property<double?>("ConfirmCommissionLimit")
                        .HasColumnType("double precision")
                        .HasColumnName("confirm_commission_limit");

                    b.Property<bool?>("IsAbsoluteCommissionValue")
                        .HasColumnType("boolean")
                        .HasColumnName("absolute_commission_status");

                    b.Property<double?>("LowerCommissionLimit")
                        .HasColumnType("double precision")
                        .HasColumnName("lower_commission_limit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("UpperCommissionLimit")
                        .HasColumnType("double precision")
                        .HasColumnName("upper_commission_limit");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("currency");
                });

            modelBuilder.Entity("CESystem.Models.Purse", b =>
                {
                    b.Property<int>("IdAccount")
                        .HasColumnType("integer")
                        .HasColumnName("id_account");

                    b.Property<int>("IdCurrency")
                        .HasColumnType("integer")
                        .HasColumnName("id_currency");

                    b.Property<double>("CashValue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0)
                        .HasColumnName("cash_value");

                    b.Property<double?>("Commission")
                        .HasColumnType("double precision")
                        .HasColumnName("commission");

                    b.Property<bool?>("IsAbsoluteCommissionValue")
                        .HasColumnType("boolean")
                        .HasColumnName("absolute_commission_status");

                    b.HasKey("IdAccount", "IdCurrency");

                    b.HasIndex("IdCurrency");

                    b.ToTable("purse");
                });

            modelBuilder.Entity("CESystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("client")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("CESystem.Models.Account", b =>
                {
                    b.HasOne("CESystem.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CESystem.Models.Purse", b =>
                {
                    b.HasOne("CESystem.Models.Account", "Account")
                        .WithMany("Purses")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CESystem.Models.Currency", "Currency")
                        .WithMany("Purses")
                        .HasForeignKey("IdCurrency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("CESystem.Models.Account", b =>
                {
                    b.Navigation("Purses");
                });

            modelBuilder.Entity("CESystem.Models.Currency", b =>
                {
                    b.Navigation("Purses");
                });

            modelBuilder.Entity("CESystem.Models.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
