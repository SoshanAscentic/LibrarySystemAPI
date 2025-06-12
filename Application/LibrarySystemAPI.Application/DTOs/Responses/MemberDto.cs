using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs.Responses
{
    public class MemberDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MemberType { get; set; }
        public int BorrowedBooksCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public MemberPermission Permissions { get; set; }
    }


}
