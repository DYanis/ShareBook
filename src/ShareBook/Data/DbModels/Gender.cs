using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class Gender
    {
        public int GenderId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Too short Genre name!")]
        [MaxLength(100, ErrorMessage = "Too long Genre name!")]
        public string GenderName { get; set; }
    }
}
