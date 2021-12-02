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
            //can create a brand without any input because the id is generated(no foreign keys)
        }

        public void Delete(int brandId)
        {
            if (brandId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            try
            {
                repo.Delete(brandId);
            }
            catch (Exception)
            {
                //repo doesnt find any brand with the given id, status code
            }
           
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
