using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareBook.Models.BookViewModels;
using ShareBook.Data;
using ShareBook.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ShareBook.FindBook;

namespace ShareBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService service)
        {
            this.bookService = service;
        }

        // GET: Book
        [Authorize]
        public ActionResult Upload()
        {
            UploadBookViewModel model = new UploadBookViewModel()
            {
                Genres = bookService.GetAllGenres()
            };
            return View(model);
        }



        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(UploadBookViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    model.OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var msg = bookService.UploadBook(model);

                    if (msg == ServiceResultMsg.BOOK_UPLOAD_SUCCESS)
                    {
                        HomePageTransferData m = new HomePageTransferData()
                        {
                            BookServiceMsg = msg
                        };
                        return RedirectToAction("Index", "Home");
                    }


                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public class test
        {
            public string isbn { get; set; }
        }

        [HttpPost]
        public ActionResult GetBookInformationByISBN(test model)
        {
            var cleanISBN = model.isbn.Replace("-", string.Empty);
            var output = BookSearch.SearchISBN(cleanISBN);

            var result = output.Result.VolumeInfo;

            UploadBookViewModel ubvm = new UploadBookViewModel()
            {
                Title = result.Title,
                Author = result.Authors.FirstOrDefault(),
                Genre = 1
            };
       
            ubvm.ISBN = cleanISBN;

            return Json(ubvm);
           // return View("Upload", ubvm);
        }



    }
}