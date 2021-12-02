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
            repo.Create(order);
            //can create a brand without any input because the id is generated(no foreign keys)
        }

        public void Delete(int orderId)
        {
            if (orderId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            try
            {
                repo.Delete(orderId);
            }
            catch (Exception)
            {
                //repo doesnt find any brand with the given id, status code
            }
            
        }

        public IQueryable<Order> ReadAll()
        {
            return repo.ReadAll();
        }

        public Order ReadOne(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            try
            {
                return repo.ReadOne(id);
            }
            catch (Exception)
            {
                //repo doesnt find any brand with the given id, status code
                return null;
            }
           
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
