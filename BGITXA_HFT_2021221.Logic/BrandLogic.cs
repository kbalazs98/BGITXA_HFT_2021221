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
            throw new NotImplementedException();
        }

        public void Delete(int brandId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Brand ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
