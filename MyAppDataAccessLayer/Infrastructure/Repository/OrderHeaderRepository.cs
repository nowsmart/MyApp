using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDBContext _context;
        public OrderHeaderRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void PaymentStatus(int Id, string SessionId, string PaymentIntentId)
        {
            var orderHeader = _context.OrderHeader.FirstOrDefault(x => x.Id == Id );
            orderHeader.DateOfPayment= DateTime.Now;
            orderHeader.PaymentIntentId = PaymentIntentId;
            orderHeader.SessionId = SessionId;
            
        }

        public void Update(OrderHeader orderHeader)
        {
            _context.OrderHeader.Update(orderHeader);
        }
        public void UpdateStatus(int Id, string OrderStatus, string? paymentStatus = null)
        {
            var order = _context.OrderHeader.FirstOrDefault(x => x.Id == Id);
            if (order != null)
            {
                order.OrderStatus = OrderStatus;
            }
            if(paymentStatus != null)
            {
                order.PaymentStatus = paymentStatus;
            }
        }
    }
}
