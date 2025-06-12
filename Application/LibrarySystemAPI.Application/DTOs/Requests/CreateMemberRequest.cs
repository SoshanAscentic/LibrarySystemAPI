using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs
{
    public class CreateMemberRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(0,2)]
        public int MemberType { get; set; } // 0 for Member, 1 for Minor Staff, 2 for Management Staff
    }
}
