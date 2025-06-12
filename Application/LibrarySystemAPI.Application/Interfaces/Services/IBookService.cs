using LibrarySystemAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.Interfaces.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void RemoveBook(string title, int publicationYear);
        void DisplayBooks();
        Book? GetBook(string title, int publicationYear);
        IEnumerable<Book> GetAllBooks();
    }
}
