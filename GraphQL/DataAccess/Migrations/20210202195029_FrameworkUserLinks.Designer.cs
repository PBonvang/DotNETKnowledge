﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210202195029_FrameworkUserLinks")]
    partial class FrameworkUserLinks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DataAccess.Entities.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("DataAccess.Entities.Framework", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Frameworks");
                });

            modelBuilder.Entity("DataAccess.Entities.FrameworkUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FrameworkId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "FrameworkId");

                    b.HasIndex("FrameworkId");

                    b.ToTable("FrameworkUserLinks");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FeatureFramework", b =>
                {
                    b.Property<Guid>("FeaturesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FrameworksId")
                        .HasColumnType("TEXT");

                    b.HasKey("FeaturesId", "FrameworksId");

                    b.HasIndex("FrameworksId");

                    b.ToTable("FeatureFramework");
                });

            modelBuilder.Entity("DataAccess.Entities.FrameworkUser", b =>
                {
                    b.HasOne("DataAccess.Entities.Framework", "Framework")
                        .WithMany()
                        .HasForeignKey("FrameworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Framework");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FeatureFramework", b =>
                {
                    b.HasOne("DataAccess.Entities.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Framework", null)
                        .WithMany()
                        .HasForeignKey("FrameworksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
