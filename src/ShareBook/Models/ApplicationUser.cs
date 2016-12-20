using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ShareBook.Data.DbModels;
using System.Collections;
using System.Collections.Generic;

namespace ShareBook.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int Coins { get; set; }

        public int GenderId { get; set; }

        public int UserStatusId { get; set; }

        // TODO: add min and max legth
        public string LastUsedIP { get; set; }

        [MaxLength(50, ErrorMessage = "First name is too long")]
        [MinLength(2, ErrorMessage = "First name is too short")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last name is too long")]
        [MinLength(2, ErrorMessage = "Last name is too short")]
        public string LastName { get; set; }

        [MaxLength(256)]
        public string PhotoPath { get; set; }

        public virtual UserStatus UserStatus { get; set; }

        public DateTime Birthday { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual ICollection<Order> AllOrders { get; set; }

        public virtual ICollection<UsersBook> OwnBooks { get; set; }
    }
}
