﻿using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public interface IOrderLogic
    {
        void Create(Order order);
        IQueryable<Order> ReadAll();
        Order ReadOne(int id);
        void Update(Order order);
        void Delete(int orderId);
    }
}
