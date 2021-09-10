using BookshelfApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetOwnedBooks()
        {
            try
            {
                return (await bookRepository.GetAllBooks()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var result = await bookRepository.GetBook(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
        [HttpPost("add")]
        public async Task <ActionResult<Book>> AddBook(Book ownedBook)
        {
            try
            {
                if (ownedBook == null) return BadRequest();

                var addedBook = await bookRepository.AddBook(ownedBook);
                return CreatedAtAction(nameof(GetBook),
                    new { id = addedBook.BookId }, addedBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding new book to database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book ownedBook)
        {
            try
            {
                if (id != ownedBook.BookId) return BadRequest("Book ID mismatch");

                var bookToUpdate = await bookRepository.GetBook(id);

                if (bookToUpdate == null) return NotFound($"Book with Id = {id} not found");
                return await bookRepository.UpdateBook(ownedBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating book");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                var bookToDelete = await bookRepository.GetBook(id);

                if (bookToDelete == null)
                {
                    return NotFound($"Book with Id = {id} not found");
                }
                return await bookRepository.DeleteBook(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting book");
            }
        }

    }
}
