using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBook.Models.BookViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Count { get; set; }

        
        public string ImgUrl { get; set; }
    }
}
