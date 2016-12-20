using ShareBook.Services;
using System.Collections.Generic;

namespace ShareBook.Models.BookViewModels
{
    public class HomePageTransferData
    {
        public ICollection<BookViewModel> TopBooks { get; set; }

        public ICollection<BookViewModel> SuggestedBooks { get; set; }

        public ServiceResultMsg BookServiceMsg { get; set; }
    }
}
