namespace ShareBook.Services.Contracts
{
    using ShareBook.Data.DbModels;
    using System.Linq;

    public interface IGenderService
    {
        IQueryable<Gender> All();
    }
}
