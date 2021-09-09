using BookshelfApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<OwnedBook> OwnedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OwnedBook>().HasData(new OwnedBook
            {
                OwnedBookId = 1,
                Title = "The Lord of the Rings",
                Author = "J. R. R. Tolkien",
                Genre = "High Fantasy",
                ReleaseYear = 1954,
                Rating = "Great!"

            });
        }
    }
}
