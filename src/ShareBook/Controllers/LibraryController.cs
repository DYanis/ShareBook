using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareBook.Models;
using ShareBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBook.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private readonly IBookService bookService;

        private readonly UserManager<ApplicationUser> _userManager;

        public LibraryController(UserManager<ApplicationUser> userManager, IBookService bookService)
        {
            this.bookService = bookService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var ownBooks = bookService.GetUsersBooksByOwner(user);
            return View(ownBooks);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
