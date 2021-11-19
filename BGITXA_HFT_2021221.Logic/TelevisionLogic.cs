using BGITXA_HFT_2021221.Models;
using BGITXA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public class TelevisionLogic : ITelevisionLogic
    {
        ITelevisionRepository repo;

        public TelevisionLogic(ITelevisionRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Television television)
        {
            repo.Create(television);
        }
        public void Delete(int televisionId)
        {
            repo.Delete(televisionId);
        }
        public IQueryable<Television> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Television television)
        {
            repo.Update(television);
        }
    }
}
