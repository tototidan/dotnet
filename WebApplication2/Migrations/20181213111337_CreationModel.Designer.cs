﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20181213111337_CreationModel")]
    partial class CreationModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication2.Models.AccountType", b =>
                {
                    b.Property<int>("accountTypeID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("accountTypeID");

                    b.ToTable("accountTypes");
                });

            modelBuilder.Entity("WebApplication2.Models.Chamber", b =>
                {
                    b.Property<int>("chamberID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("etablishmentID");

                    b.HasKey("chamberID");

                    b.HasIndex("etablishmentID");

                    b.ToTable("chamber");
                });

            modelBuilder.Entity("WebApplication2.Models.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("comment");

                    b.HasKey("commentID");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("WebApplication2.Models.Etablishment", b =>
                {
                    b.Property<int>("etablishmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("average");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<int>("etablishmenttypeID");

                    b.Property<string>("name");

                    b.Property<string>("phonenumber");

                    b.Property<string>("postalcode");

                    b.Property<string>("street");

                    b.HasKey("etablishmentID");

                    b.HasIndex("etablishmenttypeID");

                    b.ToTable("etablishment");
                });

            modelBuilder.Entity("WebApplication2.Models.EtablishmentType", b =>
                {
                    b.Property<int>("etablishmentTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("type");

                    b.HasKey("etablishmentTypeID");

                    b.ToTable("etablishmentType");
                });

            modelBuilder.Entity("WebApplication2.Models.Rating", b =>
                {
                    b.Property<int>("etablishmentID");

                    b.Property<int>("userID");

                    b.Property<int>("commentID");

                    b.Property<int>("rating");

                    b.HasKey("etablishmentID", "userID");

                    b.HasIndex("commentID");

                    b.HasIndex("userID");

                    b.ToTable("rating");
                });

            modelBuilder.Entity("WebApplication2.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("accountTypeID");

                    b.HasKey("userID");

                    b.HasIndex("accountTypeID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("WebApplication2.Models.UserEtablishment", b =>
                {
                    b.Property<int>("etablishmentID");

                    b.Property<int>("userID");

                    b.HasKey("etablishmentID", "userID");

                    b.HasIndex("userID");

                    b.ToTable("userEtablishment");
                });

            modelBuilder.Entity("WebApplication2.Models.Chamber", b =>
                {
                    b.HasOne("WebApplication2.Models.Etablishment", "etablishment")
                        .WithMany()
                        .HasForeignKey("etablishmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Models.Etablishment", b =>
                {
                    b.HasOne("WebApplication2.Models.EtablishmentType", "etablishmentType")
                        .WithMany()
                        .HasForeignKey("etablishmenttypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Models.Rating", b =>
                {
                    b.HasOne("WebApplication2.Models.Comment", "comment")
                        .WithMany()
                        .HasForeignKey("commentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Models.Etablishment", "etablishment")
                        .WithMany()
                        .HasForeignKey("etablishmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Models.User", b =>
                {
                    b.HasOne("WebApplication2.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("accountTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication2.Models.UserEtablishment", b =>
                {
                    b.HasOne("WebApplication2.Models.Etablishment", "etablishment")
                        .WithMany()
                        .HasForeignKey("etablishmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
