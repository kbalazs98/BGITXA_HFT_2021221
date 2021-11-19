﻿using BGITXA_HFT_2021221.Models;
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
            repo.Delete(brandId);
        }

        public IQueryable<Brand> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Brand brand)
        {
            repo.Update(brand);
        }
    }
}
