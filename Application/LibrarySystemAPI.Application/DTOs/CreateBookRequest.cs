using LibrarySystemAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAPI.Application.DTOs
{
    public class CreateBookRequest
    {
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Author must be between 1 and 100 characters.")]
        public string Author { get; set; }

        [Range(1450, 2025, ErrorMessage = "Publication year must be 1450 or later and 2025 or earlier.")]
        public int PublicationYear { get; set; }

        [Required]
        public Book.BookCategory Category { get; set; }
    }
}
