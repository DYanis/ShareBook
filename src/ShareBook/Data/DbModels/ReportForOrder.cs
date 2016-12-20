using ShareBook.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class ReportForOrder
    {
        public int Id { get; set; }
       
        public string FromUserId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [MinLength(20, ErrorMessage ="Too short description")]
        [MaxLength(2000, ErrorMessage = "Too long description")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        public virtual Order Order { get; set; }
    }
}
