using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BGITXA_HFT_2021221.Endpoint.Controllers
{
    [Route("Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderLogic orderLogic;

        public OrderController(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
        }

        // GET: /brandLogic
        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return orderLogic.ReadAll();
        }

        // POST /brandLogic
        [HttpPost]
        public void Post([FromBody] Order value)
        {
            orderLogic.Create(value);
        }

        // PUT /brandLogic/id
        [HttpPut("{id}")]
        public void Put([FromBody] Order value)
        {
            orderLogic.Update(value);
        }

        // DELETE /brandLogic/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderLogic.Delete(id);
        }
    }
}
