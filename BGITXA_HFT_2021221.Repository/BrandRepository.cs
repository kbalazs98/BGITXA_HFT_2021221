using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        TelevisionShopDbContext context;
        public BrandRepository(TelevisionShopDbContext context)
        {
            this.context = context;
        }
        public void Create(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public void Delete(int brandId)
        {
            context.Brands.Remove(ReadOne(brandId));
            context.SaveChanges();
        }

        public IQueryable<Brand> ReadAll()
        {
            return context.Brands;
        }

        public Brand ReadOne(int id)
        {
            return context.Brands.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            Brand old = ReadOne(brand.Id);

            old.Name = brand.Name;
            old.Televisions = brand.Televisions;
        }
    }
}
