using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs
{
    public class BorrowBookRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Member ID must be a positive integer.")]
        public int MemberID { get; set; }
    }
}
