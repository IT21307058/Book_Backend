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
    }
}
