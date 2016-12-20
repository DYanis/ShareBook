using ShareBook.Data;
using ShareBook.Data.DbModels;
using System.Linq;
using ShareBook.Services.Contracts;

namespace ShareBook.Services
{
    public class GenderService : IGenderService
    {
        private ApplicationDbContext _db;

        public GenderService(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IQueryable<Gender> All()
        {
            return this._db.Genders;
        }
    }
}
