using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareBook.Models.BookViewModels
{
    public class UploadBookViewModel
    {
        public string OwnerId { get; set; }
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public int Genre { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}
