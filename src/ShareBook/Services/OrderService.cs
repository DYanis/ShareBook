using ShareBook.Data;
using ShareBook.Data.DbModels;
using ShareBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBook.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext db;

        public OrderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ServiceResultMsg AcceptBookRequest(int orderId)
        {
            using (this.db)
            {
                try
                {
                    var req = db.Order.FirstOrDefault(x => x.Id == orderId);
                    req.State.Name = OrderStateEnum.Accept.ToString();

                    return ServiceResultMsg.OK;
                }
                catch (Exception ex)
                {
                    return ServiceResultMsg.FAIL;
                }
            }
        }

        public ServiceResultMsg DeclinedBookRequest(int orderId)
        {
            using (this.db)
            {
                try
                {
                    var req = db.Order.FirstOrDefault(x => x.Id == orderId);
                    req.State.Name = OrderStateEnum.Decline.ToString();

                    return ServiceResultMsg.OK;
                }
                catch (Exception ex)
                {
                    return ServiceResultMsg.FAIL;
                }
            }
        }

        public ServiceResultMsg FinishOrder(int orderId)
        {
            using (this.db)
            {
                try
                {
                    var req = db.Order.FirstOrDefault(x => x.Id == orderId);
                    req.State.Name = OrderStateEnum.Finished.ToString();

                    return ServiceResultMsg.OK;
                }
                catch (Exception ex)
                {
                    return ServiceResultMsg.FAIL;
                }
            }
        }

        public ServiceResultMsg Report(int orderId)
        {
            throw new NotImplementedException();
        }

        public ServiceResultMsg Report(ApplicationUser user, int orderId, string description)
        {
            try
            {
                var report = new ReportForOrder()
                {
                    Date = DateTime.Now,
                    FromUserId = user.Id,
                    OrderId = orderId,
                    Description = description
                };

                db.Order.FirstOrDefault(x => x.Id == orderId).State.Name = OrderStateEnum.Reported.ToString();
                db.ReportForOrder.Add(report);
                db.SaveChanges();
                return ServiceResultMsg.OK;
            }
            catch (Exception ex)
            {
                return ServiceResultMsg.FAIL;
            }
        }

        public ServiceResultMsg RequestBook(ApplicationUser user, int bookId)
        {
            using (this.db)
            {
                try
                {
                    var order = new Order()
                    {
                        RequesterId = user.Id,
                        StartDate = DateTime.Now,
                        UsersBookId = bookId,
                        State = new OrderStates() { Name = OrderStateEnum.Pending.ToString() }
                    };

                    db.Order.Add(order);
                    db.SaveChanges();

                    return ServiceResultMsg.OK;
                }
                catch (Exception ex)
                {
                    return ServiceResultMsg.FAIL;
                }
            }
        }
    }
}
