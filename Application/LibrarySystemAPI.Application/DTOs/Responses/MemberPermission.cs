using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs.Responses
{
    public class MemberPermission
    {
        public bool CanBorrowBooks { get; set; }
        public bool CanViewBooks { get; set; }
        public bool CanViewMembers { get; set; }
        public bool CanManageBooks { get; set; }
    }
}
