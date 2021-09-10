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
        public async Task<Book> AddBook(Book ownedBook)
        {
            var result = await appDbContext.Bookshelf.AddAsync(ownedBook);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Book> DeleteBook(int ownedBookId)
        {
            var result = await appDbContext.Bookshelf.FirstOrDefaultAsync(e => e.BookId == ownedBookId);
            if (result != null)
            {
                appDbContext.Bookshelf.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Book> GetBook(int ownedBookId)
        {
            return await appDbContext.Bookshelf.FirstOrDefaultAsync(e => e.BookId == ownedBookId);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await appDbContext.Bookshelf.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book ownedBook)
        {
            var result = await appDbContext.Bookshelf.FirstOrDefaultAsync(e => e.BookId == ownedBook.BookId);

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
