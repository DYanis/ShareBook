using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareBook.Models;

namespace ShareBook.Services
{
    public class UserService : IUserService
    {
        public ServiceResultMsg AddCredit(string userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApplicationUser> GetAll(int page)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ServiceResultMsg RemoveCredit(string userId)
        {
            throw new NotImplementedException();
        }

        public ServiceResultMsg UploadPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
