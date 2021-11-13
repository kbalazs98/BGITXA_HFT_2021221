using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Repository
{
    public interface ITelevisionRepository
    {
        //CRUD
        void Create(Television television);
        void ReadOne(int id);
        IQueryable<Television> ReadAll();
        void Update(Television television);
        void Delete(int televisionId);
    }
}
