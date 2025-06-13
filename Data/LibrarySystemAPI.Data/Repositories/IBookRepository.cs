using LibrarySystemAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Data.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Remove(Book book);
        Book GetByTitleAndYear(string title, int publicationYear);
        IEnumerable<Book> GetAll();
    }
}
