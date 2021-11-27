using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand brand);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
        void Delete(int brandId);
    }
}
