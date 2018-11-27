using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthor { get; set; }
    }
}
