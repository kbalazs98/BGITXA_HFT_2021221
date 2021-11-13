using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    public interface IOrderRepository
    {
        //CRUD
        void Create(Order order);
        Order ReadOne(int id);
        IQueryable<Order> ReadAll();
        void Update(Order order);
        void Delete(int orderId);
    }
}
