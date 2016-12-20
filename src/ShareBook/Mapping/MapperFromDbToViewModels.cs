using ShareBook.Data.DbModels;
using ShareBook.Models;
using ShareBook.Models.BookViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBook.Mapping
{
    public class MapperFromDbToViewModels
    {
        public UsersBookViewModel FromUsersBookToUsersBookViewModel(UsersBook book)
        {
            UsersBookViewModel res = new UsersBookViewModel()
            {
                IsTaken = book.IsTaken,
                Genre = book.Book.Genre.ToString(), 
                Author = book.Book.Author,
                ImgUrl = book.Book.ImgUrl,
                ISBN10 = book.Book.ISBN10,
                ISBN13  = book.Book.ISBN13,
                Title = book.Book.Title
            };

            return res;
        }

        public BookViewModel FromBookToBookViewModel(Book book)
        {
            BookViewModel res = new BookViewModel()
            {      
                Id = book.Id,   
                Author = book.Author,
                Title = book.Title,
                Count = book.Count,
                ImgUrl = book.ImgUrl
            };

            return res;
        }
    }
}
