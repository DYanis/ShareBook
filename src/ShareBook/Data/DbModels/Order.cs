using ShareBook.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShareBook.Data.DbModels
{
    public class Order
    {
        public int Id { get; set; }

        public int StateId { get; set; }
        
        public string RequesterId { get; set; }

        public int UsersBookId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public virtual UsersBook UsersBook { get; set; }

        public virtual ApplicationUser Requester { get; set; }

        public virtual OrderStates State { get; set; }
    }
}
