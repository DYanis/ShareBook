using ShareBook.Models;
using ShareBook.Models.BookViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace ShareBook.Services
{
    public interface IBookSuggestionService
    {
        ICollection<BookViewModel> GetSuggestionBook(ClaimsPrincipal user);
    }
}
