using BookStore.API.Models.Domain;
using BookStore.API.Models.DTO;
using BookStore.API.Data;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Repository.Interface;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository booksRepository;


        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var books = await booksRepository.GetAsync();
            return Ok(books);
        }

        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequestDto request)
        {
            //Map DTO to Domain Model
            var book = new Book
            {
                Title = request.title,
                Description = request.description,
                Category = request.category,
                Price = request.price,
                IsEditing = request.isEditing,
                UrlHandle = request.urlHandle
            };

            await booksRepository.CreateAsync(book);

            // Domain Model to DTO
            var respose = new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Category = book.Category,
                Price = book.Price,
                IsEditing = book.IsEditing,
                UrlHandle = book.UrlHandle
            };

            return Ok(respose);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBook(CreateBookRequestDto request)
        {
            //Map DTO to Domain Model
            var book = new Book
            {
                Title = request.title,
                Description = request.description,
                Category = request.category,
                Price = request.price,
                IsEditing = request.isEditing,
                UrlHandle = request.urlHandle
            };

            await booksRepository.UpdateAsync(book);

            // Domain Model to DTO
            var respose = new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Category = book.Category,
                Price = book.Price,
                IsEditing = book.IsEditing,
                UrlHandle = book.UrlHandle
            };

            return Ok(respose);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            try
            {
                await booksRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the book.");
            }
        }
    }
}
