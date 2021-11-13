using BGITXA_HFT_2021221.Data;
using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    class TelevisionRepository : ITelevisionRepository
    {
        TelevisionShopDbContext context;
        public TelevisionRepository(TelevisionShopDbContext context)
        {
            this.context = context;
        }
        public void Create(Television television)
        {
            throw new NotImplementedException();
        }

        public void Delete(int televisionId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Television> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Television ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Television television)
        {
            throw new NotImplementedException();
        }
    }
}
