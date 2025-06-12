﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Domain.Entities.Staff
{
    public class ManagementStaff : Staff
    {
        public ManagementStaff(string name, int memberId) : base(name, memberId) { }
        public override string GetMemberType() => "Management Staff";
    }
}
