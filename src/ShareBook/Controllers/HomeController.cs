using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareBook.Models;
using ShareBook.Models.BookViewModels;
using ShareBook.Services;
using ShareBook.FindBook;

namespace ShareBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly int NumberBooks = 4;

        private readonly IBookSuggestionService bookSuggestionService;
        private readonly IBookService bookService;
        //private readonly IUserService userService;

        public HomeController(IBookSuggestionService bookSuggestionService, IBookService bookService) //, IUserService userService)
        {
            this.bookSuggestionService = bookSuggestionService;
            this.bookService = bookService;
            //this.userService = userService;
        }

        public IActionResult Index()
        {

            var data = new HomePageTransferData();
            data.TopBooks = this.bookService.GetMostPopularBooks(NumberBooks);
            //data.SuggestedBooks = this.bookSuggestionService.GetSuggestionBook(this.User);
            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Search(string searchQuery, string searchOption, int page)
        {            
            if (searchOption == "book")
            {          
                var filteredBooks = this.bookService.FilterBooks(searchQuery, page);
                return View("~/Views/Books/SearchBooksResult.cshtml", filteredBooks);
            }

            if (searchOption == "user")
            {
                //var filteredUsers = this.userService.FilterUsers(searchQuery, page);
                //return this.PartialView("usersPaging", filteredUsers);

                //var filteredUsers = this.userService.FilterUsers(searchQuery, page);
                //return this.PartialView("_UsersPaging", filteredUsers);

            }

            return this.NoContent();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
