using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBook.FindBook
{
    public class BookSearch
    {
        private static string API_KEY = "AIzaSyAdHaikXVzCtaaDA4Tw2b2jA4_zGO3Vvkc";

        public static BooksService service = new BooksService(new BaseClientService.Initializer
        {
            ApplicationName = "ISBNBookSearch",
            ApiKey = API_KEY,
        });

        public static async Task<Volume> SearchISBN(string isbn)
        {
            Console.WriteLine("Executing a book search request for ISBN: {0} ...", isbn);
            var result = await service.Volumes.List(isbn).ExecuteAsync();

            if (result != null && result.Items != null)
            {
                var item = result.Items.FirstOrDefault();
                return item;
            }
            return null;
        }
    }
}
