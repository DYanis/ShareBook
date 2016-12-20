using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class OrderStates
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
