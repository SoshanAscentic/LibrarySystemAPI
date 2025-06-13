using LibrarySystemAPI.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Data.Repositories
{
    public interface IMemberRepository
    {
        void Add(Member member);
        Member GetById(int memberId);
        IEnumerable<Member> GetAll();
        int GetNextMemberId();
    }
}
