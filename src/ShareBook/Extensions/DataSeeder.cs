using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShareBook.Data;
using ShareBook.Data.DbModels;
using ShareBook.Models;
using ShareBook.Services;
using System.Linq;

namespace ShareBook.Extensions
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();

            SeedGenders(db);
            SeedGenres(db);
            SeedBooks(db);
            SeedUserStatuses(db);
            SeedUsers(db);
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            if (!db.Users.Any())
            {
 
            }
        }

        private static void SeedGenders(ApplicationDbContext db)
        {
            if (!db.Genders.Any())
            {
                db.Genders.Add(new Gender { GenderName = "Male" });
                db.Genders.Add(new Gender { GenderName = "Female" });
                db.Genders.Add(new Gender { GenderName = "Transgender" });
                db.SaveChanges();
            }
        }

        private static void SeedGenres(ApplicationDbContext db)
        {
            if (!db.Genres.Any())
            {
                db.Genres.Add(new Genre() { Name = "History" });
                db.Genres.Add(new Genre() { Name = "Biographies" });
                db.Genres.Add(new Genre() { Name = "Fantasy" });
                db.Genres.Add(new Genre() { Name = "Encyclopedias" });
                db.Genres.Add(new Genre() { Name = "Mystery" });
                db.Genres.Add(new Genre() { Name = "Science" });
                db.Genres.Add(new Genre() { Name = "Math" });
                db.Genres.Add(new Genre() { Name = "Bussines" });
                db.Genres.Add(new Genre() { Name = "Novel" });
                db.SaveChanges();
            }
        }

        private static void SeedBooks(ApplicationDbContext db)
        {
            if (!db.Books.Any())
            {
                db.Books.Add(new Book()
                {
                    Title = "Think and Grow Rich",
                    Author = "Napoleon Hill",
                    GenreId = 8,
                    ISBN10 = "158542711X",
                    ISBN13 = "9781585427116",
                    ImgUrl = "https://i1.helikon.bg/products/4475/20/204475/204475_b.jpg"
                });

                db.Books.Add(new Book()
                {
                    Title = "The Night in Lisbon",
                    Author = "Erich Maria Remarque",
                    GenreId = 9,
                    ISBN10 = "0449912434",
                    ISBN13 = "9780449912430",
                    ImgUrl = "https://i5.helikon.bg/products/4208/20/204208/204208_b.jpg"
                });

                db.SaveChanges();
            }
        }

        private static void SeedUserStatuses(ApplicationDbContext db)
        {
            if (!db.UserStatus.Any())
            {
                db.UserStatus.Add(new UserStatus()
                {
                    State = "Active"
                });

                db.UserStatus.Add(new UserStatus()
                {
                    State = "Blocked"
                });

                db.SaveChanges();
            }
        }

        private static void SeedOrderStates(ApplicationDbContext db)
        {
            if (!db.OrderStates.Any())
            {
                db.OrderStates.Add(new OrderStates()
                {
                    Name = OrderStateEnum.Accept.ToString()
                });

                db.OrderStates.Add(new OrderStates()
                {
                    Name = OrderStateEnum.Decline.ToString()
                });

                db.OrderStates.Add(new OrderStates()
                {
                    Name = OrderStateEnum.Finished.ToString()
                });

                db.OrderStates.Add(new OrderStates()
                {
                    Name = OrderStateEnum.Pending.ToString()
                });

                db.OrderStates.Add(new OrderStates()
                {
                    Name = OrderStateEnum.Reported.ToString()
                });
            }
        }
    }
}
