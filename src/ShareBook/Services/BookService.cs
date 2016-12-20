using System;
using System.Collections.Generic;
using ShareBook.Models;
using ShareBook.Data;
using ShareBook.Data.DbModels;
using System.Linq;
using System.Text.RegularExpressions;
using ShareBook.Mapping;
using ShareBook.Models.BookViewModels;

namespace ShareBook.Services
{
    public class BookService : IBookService
    {

        private readonly ApplicationDbContext db;

        public BookService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<UsersBookViewModel> FilterBooks(string filter, int page)
        {
            ICollection<UsersBook> books = new List<UsersBook>();

            if (page == 1 || page == 0)
            {
                page = 0;
            }
            else
            {
                page--;
            }

            books = db.UsersBook.Where(x => x.Book.Author.Contains(filter)
                               || x.Book.Title.Contains(filter)
                               || x.Book.ISBN10.Contains(filter)
                               || x.Book.ISBN13.Contains(filter)).Skip(page * 5).Take(5).ToList();

            foreach (var item in books)

            {
                item.Book = db.Books.First(x => x.Id == item.BookId);
                item.Book.Genre = db.Genres.First(x => x.Id == item.Book.GenreId);
            }

            ICollection<UsersBookViewModel> result = this.fillResultFromUsersBook(books);
            return result;
        }

        public ICollection<GenreViewModel> GetAllGenres()
        {
            ICollection<Genre> GenresDb = new List<Genre>();
            using (this.db)
            {
                GenresDb = db.Genres.ToList();
            }

            ICollection<GenreViewModel> result = new List<GenreViewModel>();
            foreach (var genre in GenresDb)
            {
                result.Add(new GenreViewModel(genre.Id, genre.Name));
            }

            return result;
        }

        public ICollection<UsersBookViewModel> GetBookByAuthor(string Author)
        {
            ICollection<UsersBook> booksByAuthor = new List<UsersBook>();
            using (this.db)
            {
                booksByAuthor = db.UsersBook.Where(x => (x.Book.Author == Author) && (x.IsDeleted == false)).ToList();
            }

            ICollection<UsersBookViewModel> result = this.fillResultFromUsersBook(booksByAuthor);
            return result;
        }

        public ICollection<UsersBookViewModel> GetBookByGenre(int GenreID)
        {
            ICollection<UsersBook> booksByGenre = new List<UsersBook>();
            using (this.db)
            {
                booksByGenre = db.UsersBook.Where(x => (x.Book.GenreId == GenreID) && (x.IsDeleted == false)).ToList();
            }

            ICollection<UsersBookViewModel> result = this.fillResultFromUsersBook(booksByGenre);
            return result;
        }

        public ICollection<UsersBookViewModel> GetBookByISBN(string ISBN)
        {
            ICollection<UsersBook> booksByISBN = new List<UsersBook>();
            using (this.db)
            {
                booksByISBN = db.UsersBook.Where(x => ((x.Book.ISBN10 == ISBN) || (x.Book.ISBN13 == ISBN)) && (x.IsDeleted == false)).ToList();
            }

            ICollection<UsersBookViewModel> result = this.fillResultFromUsersBook(booksByISBN);
            return result;
        }

        public ICollection<UsersBookViewModel> GetBookByTitle(string Title)
        {
            ICollection<UsersBook> booksByTitle = new List<UsersBook>();
            using (this.db)
            {
                booksByTitle = db.UsersBook.Where(x => (x.Book.Title == Title) && (x.IsDeleted == false)).ToList();
            }

            ICollection<UsersBookViewModel> result = this.fillResultFromUsersBook(booksByTitle);
            return result;
        }

        public IList<BookViewModel> GetMostPopularBooks(int numberOfBooks)
        {
            IList<Book> books = new List<Book>();

            using (this.db)
            {
                books = db.Books.OrderByDescending(x => x.Count).Take(numberOfBooks).ToList();
            }

            IList<BookViewModel> result = this.fillResultFromBook(books).ToList();

            return result;
        }

        public ServiceResultMsg RemoveBook(UsersBook book)
        {
            using (this.db)
            {
                book.IsDeleted = true;
                try
                {
                    db.Update(book);
                    db.SaveChanges();
                    return ServiceResultMsg.BOOK_DELETE_SUCCESS;
                }
                catch (Exception e)
                {
                    return ServiceResultMsg.BOOK_DELETE_FAIL;
                }
            }
        }

        private int CountDigits(string str)
        {
            int count = 0;
            foreach (var ch in str)
            {
                if (ch >= '0' && ch <= '9') count++;
            }
            return count;
        }



        public ServiceResultMsg UploadBook(UploadBookViewModel ubvm)
        {
            if (ubvm.ISBN == null)
            {
                ubvm.ISBN = "";
            }
            ubvm.ISBN = ubvm.ISBN.Replace("-", String.Empty);
            if (!db.Books.Any(x => (x.ISBN10 == ubvm.ISBN) || (x.ISBN13 == ubvm.ISBN)))
            {
                Book book = new Book();
                this.FillBookDbModels(ubvm, book);
                using (db)
                {
                    db.Books.Add(book);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return ServiceResultMsg.BOOK_UPLOAD_FAIL;
                    }

                    UsersBook userBook = new UsersBook();
                    int id = db.Books.First(x => (x.ISBN10 == ubvm.ISBN) || (x.ISBN13 == ubvm.ISBN)).Id;
                    this.FillUserBookDbModels(ubvm, userBook, id);

                    db.UsersBook.Add(userBook);
                    try
                    {
                        db.SaveChanges();
                        return ServiceResultMsg.BOOK_UPLOAD_SUCCESS;
                    }
                    catch (Exception e)
                    {
                        return ServiceResultMsg.BOOK_UPLOAD_FAIL;
                    }
                }
            }
            else
            {
                using (db)
                {
                    UsersBook userBook = new UsersBook();
                    int id = db.Books.First(x => (x.ISBN10 == ubvm.ISBN) || (x.ISBN13 == ubvm.ISBN)).Id;
                    this.FillUserBookDbModels(ubvm, userBook, id);

                    db.UsersBook.Add(userBook);
                    try
                    {
                        db.SaveChanges();
                        return ServiceResultMsg.BOOK_UPLOAD_SUCCESS;
                    }
                    catch (Exception e)
                    {
                        return ServiceResultMsg.BOOK_UPLOAD_FAIL;
                    }
                }
            }
        }

        private void FillBookDbModels(UploadBookViewModel ubvm, Book book)
        {
            ValidateGenreAndISBN(ubvm);

            book.GenreId = ubvm.Genre;
            if (CountDigits(ubvm.ISBN) == 10)
            {
                book.ISBN10 = ubvm.ISBN;
                book.ISBN13 = "";
            }
            if (CountDigits(ubvm.ISBN) == 13)
            {
                book.ISBN10 = "";
                book.ISBN13 = ubvm.ISBN;
            }
            book.Title = ubvm.Title;
            book.Author = ubvm.Author;
        }

        private void FillUserBookDbModels(UploadBookViewModel ubvm, UsersBook userBook, int bookId)
        {
            userBook.BookId = bookId;
            userBook.OwnerId = ubvm.OwnerId;
            userBook.IsTaken = false;
        }

        private void ValidateGenreAndISBN(UploadBookViewModel ubvm)
        {
            if (ubvm.Genre < 1 && ubvm.Genre > this.db.Genres.Count())
                throw new ArgumentOutOfRangeException("Invalid genreId");
            string isbnRegex = @"((?:[\dX]{13})|(?:[\d\-X]{17})|(?:[\dX]{10})|(?:[\d\-X]{13}))";
            Regex rgx = new Regex(isbnRegex);

            if (!rgx.IsMatch(ubvm.ISBN) && !rgx.IsMatch(ubvm.ISBN))
                throw new Exception("Invalid ISBN");
        }

        private ICollection<UsersBookViewModel> fillResultFromUsersBook(ICollection<UsersBook> collection)
        {
            ICollection<UsersBookViewModel> result = new List<UsersBookViewModel>();
            MapperFromDbToViewModels mapper = new MapperFromDbToViewModels();

            foreach (var item in collection)
            {
                result.Add(mapper.FromUsersBookToUsersBookViewModel(item));
            }

            return result;
        }

        private ICollection<BookViewModel> fillResultFromBook(ICollection<Book> collection)
        {
            ICollection<BookViewModel> result = new List<BookViewModel>();
            MapperFromDbToViewModels mapper = new MapperFromDbToViewModels();

            foreach (var item in collection)
            {
                result.Add(mapper.FromBookToBookViewModel(item));
            }

            return result;
        }

        public ICollection<UsersBookViewModel> GetUsersBooksByOwner(ApplicationUser user)
        {
            using (this.db)
            {
                var UsersBooks = db.UsersBook.Where(x => x.OwnerId == user.Id);

                var result = new List<UsersBookViewModel>();
                foreach (var b in UsersBooks)
                {
                    result.Add(new UsersBookViewModel()
                    {
                        Author = b.Book.Author,
                        Genre = b.Book.Genre.Name,
                        IsTaken = b.IsTaken
                    });
                }

                return result;
            }
        }
    }
}
