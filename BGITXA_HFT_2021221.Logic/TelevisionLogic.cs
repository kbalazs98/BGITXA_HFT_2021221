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
            if (television.Model == null)
            {
                throw new ArgumentNullException();
            }
            if (television.Id == 0)
            {
                throw new ArgumentNullException();
            }
            repo.Create(television);
        }
        public void Delete(int televisionId)
        {
            if (televisionId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            repo.Delete(televisionId);
        }
        public IQueryable<Television> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Television television)
        {
            if (television.Model == null)
            {
                throw new ArgumentNullException();
            }
            if (television.Id == 0)
            {
                throw new ArgumentNullException();
            }
            repo.Update(television);
        }

        public IEnumerable<KeyValuePair<string, double>> AveragePriceOfBrand()
        {
            return repo.ReadAll()
                .GroupBy(x => x.Brand)
                .Select(x => new KeyValuePair<string, double>
                (x.Key.Name, x.Average(x => x.Price) ?? 0));
        }
        public IEnumerable<KeyValuePair<string, int>> CountTvByOrder()
        {
            return repo.ReadAll().GroupBy(x => x.Order)
                 .Select(x => new KeyValuePair<string, int>(x.Key.CustomerName, x.Key.Televisions.Count()));
        }
        public IEnumerable<KeyValuePair<string, double>> AveragePriceOfOrder()
        {
            return repo.ReadAll()
               .GroupBy(x => x.Order)
               .Select(x => new KeyValuePair<string, double>
               (x.Key.CustomerName, x.Average(x => x.Price) ?? 0));
        }
        public IEnumerable<Order> OrdersInOrderByPrice()
        {
            return repo.ReadAll()
                   .GroupBy(x => x.Order)
                   .OrderBy(x => x.Average(x => x.Price))
                   .Select(x => x.Key);
        }
        public Television CheapestTvOfTheBrand(int brandId)
        {
            return repo.ReadAll().OrderBy(x => x.Price).Where(x => x.Brand.Id == brandId).FirstOrDefault();
        }
    }
}
