using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    public class TelevisionRepository : ITelevisionRepository
    {
        TelevisionShopDbContext context;
        public TelevisionRepository(TelevisionShopDbContext context)
        {
            this.context = context;
        }
        public void Create(Television television)
        {
            context.Televisions.Add(television);
            context.SaveChanges();
        }

        public void Delete(int televisionId)
        {
            context.Televisions.Remove(ReadOne(televisionId));
            context.SaveChanges();
        }

        public IQueryable<Television> ReadAll()
        {
            return context.Televisions;
        }

        public Television ReadOne(int id)
        {
            ;
            return context.Televisions.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Television television)
        {
            Television old = ReadOne(television.Id);
            old.Model = television.Model;
            old.Order = television.Order;
            old.OrderId = television.OrderId;
            old.Price = television.Price;
            context.SaveChanges();
        }
    }
}
