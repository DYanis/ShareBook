using ShareBook.Models;
using System.Collections;
using System.Collections.Generic;

namespace ShareBook.Services
{
    public interface IUserService
    {
        ICollection<ApplicationUser> GetAll(int page);

        ApplicationUser GetById(string id);

        ApplicationUser GetByUsername(string username);

        ApplicationUser GetByEmail(string email);

        ServiceResultMsg AddCredit(string userId);

        ServiceResultMsg RemoveCredit(string userId);

        ServiceResultMsg UploadPhoto();
    }
}
