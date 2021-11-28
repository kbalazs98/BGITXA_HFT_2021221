using BGITXA_HFT_2021221.Models;
using BGITXA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository repo;

        public BrandLogic(IBrandRepository repo)
        {
            this.repo = repo;
        }
        
        public void Create(Brand brand)
        {
            repo.Create(brand);
        }

        public void Delete(int brandId)
        {
            if (brandId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            repo.Delete(brandId);
        }

        public IQueryable<Brand> ReadAll()
        {
            return repo.ReadAll();
        }

        public Brand ReadOne(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return repo.ReadOne(id);
        }

        public void Update(Brand brand)
        {
            if (brand.Id == 0)
            {
                throw new ArgumentNullException();
            }
            repo.Update(brand);
        }
    }
}
