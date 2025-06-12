using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs
{
    public class LoginDto
    {
        [Required]
        public int MemberID { get; set; }
    }
}
