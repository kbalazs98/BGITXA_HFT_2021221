using BGITXA_HFT_2021221.Models;
using BGITXA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public class OrderLogic : IOrderLogic
    {
        IOrderRepository repo;

        public OrderLogic(IOrderRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int orderId)
        {
            throw new NotImplementedException();
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
