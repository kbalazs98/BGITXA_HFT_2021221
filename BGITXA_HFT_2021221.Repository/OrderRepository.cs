using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    class OrderRepository : IOrderRepository
    {
        TelevisionShopDbContext context;
        public OrderRepository(TelevisionShopDbContext context)
        {
            this.context = context;
        }
        public void Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Delete(int orderId)
        {
            context.Orders.Remove(ReadOne(orderId));
            context.SaveChanges();
        }

        public IQueryable<Order> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Order ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
