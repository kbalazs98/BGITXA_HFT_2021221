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
            if(order.Id == 0)
            {
                throw new ArgumentNullException();
            }
            repo.Create(order);
        }

        public void Delete(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            repo.Delete(orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Order order)
        {
            if (order.Id == 0)
            {
                throw new ArgumentNullException();
            }
            repo.Update(order);
        }
    }
}
