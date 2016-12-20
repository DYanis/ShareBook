namespace ShareBook.Services
{
    using Microsoft.EntityFrameworkCore;
    using ShareBook.Data;
    using ShareBook.Data.DbModels;
    using System.Linq;
    using ShareBook.Services.Contracts;

    public class UserStatusService : IUserStatusService
    {
        private DbSet<UserStatus> userStatusService;

        public UserStatusService(ApplicationDbContext _db)
        {
            this.userStatusService = _db.UserStatus;           
        }

        public int GetActiveStatusId()
        {
            return this.userStatusService.FirstOrDefault(s => s.State == "Active").Id;
        }

        public int GetBlockedStatusId()
        {
            return this.userStatusService.FirstOrDefault(s => s.State == "Blocked").Id;
        }
    }
}
