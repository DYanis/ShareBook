using ShareBook.Data;
using ShareBook.Data.DbModels;
using ShareBook.Models;
using ShareBook.Models.BookViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareBook.Services
{
    public class BookSuggestionService : IBookSuggestionService
    {
        private readonly ApplicationDbContext db;

        private const byte DEFAULT_SUGGESTED_BOOKS_COUNT = 5;

        public BookSuggestionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        //public ICollection<UsersBookViewModel> GetUserSuggestionBooks(string userId, byte suggestedBooksCount = DEFAULT_SUGGESTED_BOOKS_COUNT)
        //{
        //    var user = this.db.Users.FirstOrDefault(u => u.Id == userId);
        //    if (user != null)
        //    {
        //        var ownBooks = user.OwnBooks.ToList();
        //        var xxxx = ownBooks.GroupBy(b => b.Book.Genre.Id).ToDictionary(x => x.First().Book.Genre.Name, y=> y.Count());
        //    }


        //    return null;
        //}

        public ICollection<BookViewModel> GetSuggestionBook(ClaimsPrincipal user)
        {
            var books = this.db.Books.Take(DEFAULT_SUGGESTED_BOOKS_COUNT).ToList();

            var result = new List<BookViewModel>();

            foreach (var b in books)
            {
                result.Add(new BookViewModel()
                {
                    Author = b.Author,
                    Count = b.Count,
                    Title = b.Title,
                    ImgUrl = b.ImgUrl

                });
            }

            return result;
        }
    }
}
