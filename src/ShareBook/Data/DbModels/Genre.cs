using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "Too long genre name")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
