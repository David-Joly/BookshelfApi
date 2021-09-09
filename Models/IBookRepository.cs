using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Models
{
    public interface IBookRepository
    {
        Task<IEnumerable<OwnedBook>> GetOwnedBooks();
        Task<OwnedBook> GetBook(int ownedBookId);
        Task<OwnedBook> AddBook(OwnedBook ownedBook);
        Task<OwnedBook> UpdateBook(OwnedBook ownedBook);
        Task <OwnedBook> DeleteBook(int ownedBookId);
    }
}
