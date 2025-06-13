using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MemberDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MemberDto>> GetAllMembers()
        {
            try
            {
                var members = memberService.GetAllMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving members.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MemberDto> GetMember(int id)
        {
            if (id <= 0)
                return BadRequest("Member ID must be positive.");

            try
            {
                var member = memberService.GetMemberById(id);
                if (member == null)
                    return NotFound($"Member with ID {id} not found.");

                return Ok(member);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the member.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MemberDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MemberDto> AddMember(CreateMemberDto createMemberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var member = memberService.AddMember(createMemberDto);
                return CreatedAtAction(nameof(GetMember), new { id = member.MemberID }, member);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding the member.");
            }

        }
    }
}
