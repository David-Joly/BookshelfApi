using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Search(string title);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int ownedBookId);
        Task<Book> AddBook(Book ownedBook);
        Task<Book> UpdateBook(Book ownedBook);
        Task <Book> DeleteBook(int ownedBookId);
    }
}
