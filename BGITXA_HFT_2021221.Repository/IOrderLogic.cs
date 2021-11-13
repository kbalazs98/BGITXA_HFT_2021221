using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    public interface IOrderLogic
    {
        //CRUD
        void Create(Order order);
        void ReadOne(int id);
        IQueryable<Order> ReadAll();
        void Update(Order order);
        void Delete(int orderId);
    }
}
