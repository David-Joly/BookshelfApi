using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookshelfApi.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Rating { get; set; }

    }
}
