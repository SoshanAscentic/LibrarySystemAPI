using LibrarySystemAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Interfaces.Services
{
    public interface IBorrowingService
    {
        bool BorrowBook(BorrowReturnDto borrowDto);
        bool ReturnBook(BorrowReturnDto returnDto);
    }
}
