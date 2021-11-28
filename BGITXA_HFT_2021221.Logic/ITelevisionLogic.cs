using BGITXA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Logic
{
    public interface ITelevisionLogic
    {
        IEnumerable<KeyValuePair<string, double>> AveragePriceOfOrder();

        IEnumerable<Order> OrdersInOrderByPrice();

        IEnumerable<KeyValuePair<string, double>> AveragePriceOfBrand();

        IEnumerable<KeyValuePair<string, int>> CountTvByOrder();

        Television CheapestTvOfTheBrand(int brandId);

        void Create(Television television);
        IQueryable<Television> ReadAll();
        Television ReadOne(int id);
        void Update(Television television);
        void Delete(int televisionId);
    }
}
