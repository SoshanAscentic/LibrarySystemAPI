using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemAPI.API.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    [Produces ("application/json")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MemberDto> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var member = authenticationService.Login(loginDto);
                if (member == null)
                    return NotFound("Member not found. please sign up first");
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured during login");
            }
        }


        [HttpPost("signup")]
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MemberDto> Signup(CreateMemberDto createMemberDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var member = authenticationService.SignUp(createMemberDto);
                return CreatedAtAction(nameof(Login), new { memberId = member.MemberID }, member);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred during signup.");
            }
        }

    }
}
