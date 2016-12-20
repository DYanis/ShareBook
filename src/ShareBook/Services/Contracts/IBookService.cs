using ShareBook.Models.BookViewModels;
using ShareBook.Data.DbModels;
using System.Collections.Generic;
using ShareBook.Models;

namespace ShareBook.Services
{
    public interface IBookService
    {
        ServiceResultMsg UploadBook(UploadBookViewModel ubvm);
        ServiceResultMsg RemoveBook(UsersBook book);
        ICollection<UsersBookViewModel> GetBookByISBN(string ISBN);
        ICollection<UsersBookViewModel> GetBookByTitle(string title);
        ICollection<UsersBookViewModel> GetBookByAuthor(string author);
        ICollection<UsersBookViewModel> GetBookByGenre(int GenreID);
        IList<BookViewModel> GetMostPopularBooks(int numberOfBooks);
        ICollection<GenreViewModel> GetAllGenres();
        ICollection<UsersBookViewModel> FilterBooks(string filter, int page);
        ICollection<UsersBookViewModel> GetUsersBooksByOwner(ApplicationUser user);
    }
}
