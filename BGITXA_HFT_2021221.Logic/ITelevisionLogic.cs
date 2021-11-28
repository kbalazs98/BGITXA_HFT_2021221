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
        IQueryable<KeyValuePair<string, double>> AveragePriceOfOrder();

        IQueryable<Order> OrdersInOrderByPrice();

        IQueryable<KeyValuePair<string, double>> AveragePriceOfBrand();

        IQueryable<KeyValuePair<string, int>> CountTvByOrder();

        Television CheapestTvOfTheBrand(int brandId);

        void Create(Television television);
        IQueryable<Television> ReadAll();
        void Update(Television television);
        void Delete(int televisionId);
    }
}
