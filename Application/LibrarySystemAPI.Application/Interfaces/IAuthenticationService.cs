using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Interfaces
{
    public interface IAuthenticationService
    {
        MemberDto Login(LoginDto loginDto);
        MemberDto SignUp(CreateMemberDto createMemberDto);
    }
}
