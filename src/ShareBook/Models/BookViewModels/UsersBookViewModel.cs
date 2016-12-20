using ShareBook.Data.DbModels;

namespace ShareBook.Models
{
    public class UsersBookViewModel
    {
        public bool IsTaken { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public string ISBN13 { get; set; }

        public string ISBN10 { get; set; }

        public string Title { get; set; }

        public string ImgUrl { get; set; }

    }
}
