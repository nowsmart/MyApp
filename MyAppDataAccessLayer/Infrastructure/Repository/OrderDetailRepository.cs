﻿using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
  public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
    private ApplicationDBContext _context;
    public OrderDetailRepository(ApplicationDBContext context):base(context)
    {
      _context = context;
    }

    public void Update(OrderDetail orderDetail)
    {
      _context.OrderDetail.Update(orderDetail);
            
    }
  }
}
