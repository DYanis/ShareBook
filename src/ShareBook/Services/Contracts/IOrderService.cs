using ShareBook.Models;

namespace ShareBook.Services
{
    public interface IOrderService
    {
        ServiceResultMsg RequestBook(ApplicationUser user, int bookId);

        ServiceResultMsg AcceptBookRequest(int orderId);

        ServiceResultMsg DeclinedBookRequest(int orderId);

        ServiceResultMsg FinishOrder(int orderId);

        ServiceResultMsg Report(ApplicationUser user, int orderId, string description);
    }
}
