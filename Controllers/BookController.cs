using BMS.Data;
using BMS.Models;
using BMS.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDBContext dBContext;

        public BookController(BookDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult getAllBooks()
        {
            var books = dBContext.Books.ToList();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult addBook(AddBookRequestDTO request)
        {
            var domainModelBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Description = request.Description,
                ISBN = request.ISBN,
                publicationDate = request.publicationDate
            };

            dBContext.Books.Add(domainModelBook);
            dBContext.SaveChanges();

            return Ok(domainModelBook);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getBookId(Guid id)
        {
            var book = dBContext.Books.Find(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        public IActionResult updateBook(Guid id, AddBookRequestDTO request)
        {
            var book = dBContext.Books.Find(id);

            if (book == null) {
                return NotFound();
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.Description = request.Description;
            book.ISBN = request.ISBN;
            book.publicationDate = request.publicationDate;

            dBContext.SaveChanges();
            return Ok(book);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult deleteBook(Guid id)
        {
            var book = dBContext.Books.Find(id);

            if(book is not null)
            {
                dBContext.Books.Remove(book);
                dBContext.SaveChanges();
            }

            return Ok();
        }
    }
}
