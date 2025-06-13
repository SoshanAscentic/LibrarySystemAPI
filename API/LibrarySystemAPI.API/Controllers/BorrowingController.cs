using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService borrowingService;
        public BorrowingController(IBorrowingService borrowingService)
        {
            this.borrowingService = borrowingService ?? throw new ArgumentNullException(nameof(borrowingService));
        }
        [HttpPost("borrow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult BorrowBook(BorrowReturnDto borrowBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var success = borrowingService.BorrowBook(borrowBookDto);
                if (!success)
                    return BadRequest("Unable to borrow book. Please check if book is available and member has borrowing permissions.");

                return Ok(new
                {
                    message = "Book borrowed successfully!",
                    book = borrowBookDto.Title,
                    year = borrowBookDto.PublicationYear,
                    memberId = borrowBookDto.MemberID
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while borrowing the book.");
            }
        }

        [HttpPost("return")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ReturnBook(BorrowReturnDto returnDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var success = borrowingService.ReturnBook(returnDto);
                if (!success)
                    return BadRequest("Unable to return book. Please check if book is currently borrowed by this member.");

                return Ok(new
                {
                    message = "Book returned successfully!",
                    book = returnDto.Title,
                    year = returnDto.PublicationYear,
                    memberId = returnDto.MemberID
                });
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
                return StatusCode(500, "An error occurred while returning the book.");
            }
        }

    }
}
