using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces ("application/json")]
    public class BooksController :ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        /**/


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BookDto>> GetAllBooks()
        {
            try
            {
                var books = bookService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving books.");
            }
        }

        [HttpGet("{title}/{year}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDto> GetBook(string title, int year)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title cannot be empty.");

            if (year < 1450 || year > DateTime.Now.Year)
                return BadRequest($"Publication year must be between 1450 and {DateTime.Now.Year}.");

            try
            {
                var book = bookService.GetBook(title, year);
                if (book == null)
                    return NotFound($"Book '{title}' ({year}) not found.");

                return Ok(book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the book.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDto> AddBook(CreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var book = bookService.AddBook(createBookDto);
                return CreatedAtAction(nameof(GetBook),
                    new { title = book.Title, year = book.PublicationYear }, book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the book.");
            }
        }

        [HttpDelete("{title}/{year}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveBook(string title, int year)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title cannot be empty.");

            if (year < 1450 || year > DateTime.Now.Year)
                return BadRequest($"Publication year must be between 1450 and {DateTime.Now.Year}.");

            try
            {
                var success = bookService.RemoveBook(title, year);
                if (!success)
                    return NotFound($"Book '{title}' ({year}) not found.");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while removing the book.");
            }
        }


    }
}
