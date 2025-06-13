using LibrarySystemAPI.Domain.Entities;
using LibrarySystemAPI.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Data.InMemoryStorage
{
    public class DataStorage
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();
    }
}
