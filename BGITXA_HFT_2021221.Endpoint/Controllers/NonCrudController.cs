using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        ITelevisionLogic tvlogic;

        public NonCrudController(ITelevisionLogic tvlogic)
        {
            this.tvlogic = tvlogic;
        }

        [HttpGet("AveragePriceOfBrand")]
        public IEnumerable<KeyValuePair<string, double>> AveragePriceOfBrand()
        {
            return tvlogic.AveragePriceOfBrand();
        }

        [HttpGet("CountTvByOrder")]
        public IEnumerable<KeyValuePair<string, int>> CountTvByOrder()
        {
            return tvlogic.CountTvByOrder();
        }

        [HttpGet("AveragePriceOfOrder")]
        public IEnumerable<KeyValuePair<string, double>> AveragePriceOfOrder()
        {
            return tvlogic.AveragePriceOfOrder();
        }

        [HttpGet("OrdersInOrderByPrice")]
        public IEnumerable<Order> OrdersInOrderByPrice()
        {
            return tvlogic.OrdersInOrderByPrice();
        }

        [HttpGet("CheapestTvOfTheBrand")]
        public Television CheapestTvOfTheBrand([FromBody]int brandId)
        {
            return tvlogic.CheapestTvOfTheBrand(brandId);
        }
    }
}
