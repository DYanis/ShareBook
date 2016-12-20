using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class Book
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string ImgUrl { get; set; }

        [StringLength(13, ErrorMessage = "length must be 13 characters")]
        public string ISBN13 { get; set; }

        [StringLength(10, ErrorMessage = "length must be 10 characters")]
        public string ISBN10 { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Too short title")]
        [MaxLength(256, ErrorMessage = "Too long title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "Too long author name")]
        public string Author { get; set; }

        public int Count { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
