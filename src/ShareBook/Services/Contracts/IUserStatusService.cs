namespace ShareBook.Services.Contracts
{
    public interface IUserStatusService
    {
        int GetActiveStatusId();

        int GetBlockedStatusId();
    }
}
