using System;
using System.Linq;
using BGITXA_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;

namespace BGITXA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TelevisionShopContext tsc = new TelevisionShopContext();
            var res1 = tsc.Televisions.ToList();

            var res2 = tsc.Televisions
                .Include(x => x.Brand)
                .ToList()
                .GroupBy(x => x.Brand)
                .Select(x => new
                {
                    BrandName = x.Key.Name,
                    AvaragePrice = x.Average(y => y.Price)
                });

            var res3 = tsc.Orders
                .Include(x=> x.Televisions)
                .ThenInclude(x=>x.Brand)
                .ToList();
                
            foreach(var item in res2)
            {
                Console.WriteLine(item.BrandName + " - " + item.AvaragePrice);
            }
        }
    }
}
