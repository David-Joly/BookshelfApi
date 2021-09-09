using BookshelfApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<OwnedBook> AddBook(OwnedBook ownedBook)
        {
            var result = await appDbContext.OwnedBooks.AddAsync(ownedBook);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<OwnedBook> DeleteBook(int ownedBookId)
        {
            var result = await appDbContext.OwnedBooks.FirstOrDefaultAsync(e => e.OwnedBookId == ownedBookId);
            if (result != null)
            {
                appDbContext.OwnedBooks.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<OwnedBook> GetBook(int ownedBookId)
        {
            return await appDbContext.OwnedBooks.FirstOrDefaultAsync(e => e.OwnedBookId == ownedBookId);
        }

        public async Task<IEnumerable<OwnedBook>> GetOwnedBooks()
        {
            return await appDbContext.OwnedBooks.ToListAsync();
        }

        public async Task<OwnedBook> UpdateBook(OwnedBook ownedBook)
        {
            var result = await appDbContext.OwnedBooks.FirstOrDefaultAsync(e => e.OwnedBookId == ownedBook.OwnedBookId);

            if (result != null)
            {
                result.Title = ownedBook.Title;
                result.Author = ownedBook.Author;
                result.Genre = ownedBook.Genre;
                result.ReleaseYear = ownedBook.ReleaseYear;
                result.Rating = ownedBook.Rating;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
