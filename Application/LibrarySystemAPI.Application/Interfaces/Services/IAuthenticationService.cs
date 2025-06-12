using LibrarySystemAPI.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Member? Login();
        Member? SignUp();
    }
}
