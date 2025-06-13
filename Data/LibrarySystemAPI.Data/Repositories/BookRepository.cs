using LibrarySystemAPI.Data.InMemoryStorage;
using LibrarySystemAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataStorage dataStorage;

        public BookRepository(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage ?? throw new ArgumentNullException(nameof(dataStorage));
        }

        public void Add(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            dataStorage.Books.Add(book);
        }

        public void Remove(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            dataStorage.Books.Remove(book);
        }

        public Book GetByTitleAndYear(string title, int publicationYear)
        {
            return dataStorage.Books.FirstOrDefault(b =>
                string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase) &&
                b.PublicationYear == publicationYear);
        }

        public IEnumerable<Book> GetAll()
        {
            return dataStorage.Books.AsReadOnly();
        }
    }
}
