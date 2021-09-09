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
    public class OwnedBooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public OwnedBooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnedBook>>> GetOwnedBooks()
        {
            try
            {
                return (await bookRepository.GetOwnedBooks()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OwnedBook>> GetBook(int id)
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
        [HttpPost]
        public async Task <ActionResult<OwnedBook>> AddBook(OwnedBook ownedBook)
        {
            try
            {
                if (ownedBook == null) return BadRequest();

                var addedBook = await bookRepository.AddBook(ownedBook);
                return CreatedAtAction(nameof(GetBook),
                    new { id = addedBook.OwnedBookId }, addedBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding new book to database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<OwnedBook>> UpdateBook(int id, OwnedBook ownedBook)
        {
            try
            {
                if (id != ownedBook.OwnedBookId) return BadRequest("Book ID mismatch");

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
        public async Task<ActionResult<OwnedBook>> DeleteBook(int id)
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
