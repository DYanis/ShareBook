using ShareBook.Models;

namespace ShareBook.Data.DbModels
{
    public class UsersBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string OwnerId { get; set; }

        public bool IsTaken { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual Book Book { get; set; }
    }
}
