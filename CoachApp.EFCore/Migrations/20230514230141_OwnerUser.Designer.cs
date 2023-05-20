﻿// <auto-generated />
using System;
using CoachApp.EFCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoachApp.EFCore.Migrations
{
    [DbContext(typeof(CoachAppContext))]
    [Migration("20230514230141_OwnerUser")]
    partial class OwnerUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoachApp.Domain.Clients.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CoachApp.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoachApp.Domain.Clients.Client", b =>
                {
                    b.OwnsOne("CoachApp.Domain.Clients.Models.Adress", "Adress", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AdditionalInformation")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.OwnsOne("CoachApp.Domain.Clients.Models.ContactDetails", "ContactDetails", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Adress")
                        .IsRequired();

                    b.Navigation("ContactDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("CoachApp.Domain.Users.User", b =>
                {
                    b.OwnsOne("CoachApp.Domain.Users.Models.CompanyInformation", "CompanyInformation", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Activity")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SAPAgreementNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SiretNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("CoachApp.Domain.Users.Models.ContactDetails", "ContactDetails", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("CompanyInformation");

                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}