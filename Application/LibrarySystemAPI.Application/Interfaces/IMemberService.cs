using LibrarySystemAPI.Application.DTOs;
using LibrarySystemAPI.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Interfaces
{
    public interface IMemberService
    {
        MemberDto AddMember(CreateMemberDto createMemberDto);
        IEnumerable<MemberDto> GetAllMembers();
        MemberDto GetMemberById(int memberId);
    }
}
