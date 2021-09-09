﻿// <auto-generated />
using BookshelfApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookshelfApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210909201852_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookshelfApi.Models.OwnedBook", b =>
                {
                    b.Property<int>("OwnedBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnedBookId");

                    b.ToTable("OwnedBooks");

                    b.HasData(
                        new
                        {
                            OwnedBookId = 1,
                            Author = "J. R. R. Tolkien",
                            Genre = "High Fantasy",
                            Rating = "Great!",
                            ReleaseYear = 1954,
                            Title = "The Lord of the Rings"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
