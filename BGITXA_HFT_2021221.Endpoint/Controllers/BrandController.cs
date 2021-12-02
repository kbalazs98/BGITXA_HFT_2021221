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
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            try
            {
                brandLogic.Update(value);
            }
            catch (Exception)
            {
                //without id database cannot update, status code
            }
            
        }

        // DELETE /brandLogic/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                brandLogic.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                //negative Id doesnt exist in database,should throw status code
            }
            
        }
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            try
            {
                return brandLogic.ReadOne(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                //negative Id doesnt exist in database,should throw status code
                return null;
            }
        }
    }
}
