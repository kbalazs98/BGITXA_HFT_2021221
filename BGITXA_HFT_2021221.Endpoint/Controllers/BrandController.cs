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
    [Route("brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic brandLogic;

        public BrandController(IBrandLogic brandLogic)
        {
            this.brandLogic = brandLogic;
        }

        // GET: /brandLogic
        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return brandLogic.ReadAll();
        }

        // POST /brandLogic
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            brandLogic.Create(value);
        }

        // PUT /brandLogic/id
        [HttpPut("{id}")]
        public void Put([FromBody] Brand value)
        {
            brandLogic.Update(value);
        }

        // DELETE /brandLogic/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            brandLogic.Delete(id);
        }
    }
}
