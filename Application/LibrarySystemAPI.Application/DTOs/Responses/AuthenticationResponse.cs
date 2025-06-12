using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs.Responses
{
    public class AuthenticationResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public MemberDto Member { get; set; }
    }
}
