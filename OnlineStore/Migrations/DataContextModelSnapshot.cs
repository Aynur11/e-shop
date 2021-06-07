﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore;

namespace OnlineStore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Article")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductImageId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductImageId");

                    b.HasIndex("SectionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineStore.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("OnlineStore.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("OnlineStore.Models.SectionImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId")
                        .IsUnique();

                    b.ToTable("SectionImage");
                });

            modelBuilder.Entity("OnlineStore.Models.Product", b =>
                {
                    b.HasOne("OnlineStore.Models.ProductImage", "ProductImages")
                        .WithMany()
                        .HasForeignKey("ProductImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStore.Models.Section", "Section")
                        .WithMany("Products")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductImages");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("OnlineStore.Models.SectionImage", b =>
                {
                    b.HasOne("OnlineStore.Models.Section", "Section")
                        .WithOne("Image")
                        .HasForeignKey("OnlineStore.Models.SectionImage", "SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("OnlineStore.Models.Section", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
