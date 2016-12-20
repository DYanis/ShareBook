using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class UserStatus
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string State { get; set; }
    }
}
