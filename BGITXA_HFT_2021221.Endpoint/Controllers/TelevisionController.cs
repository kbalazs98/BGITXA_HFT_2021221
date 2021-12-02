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
    [Route("televisions")]//          /default route
    [ApiController]
    public class TelevisionController : ControllerBase
    {
        ITelevisionLogic tvlogic;

        public TelevisionController(ITelevisionLogic tvlogic)
        {
            this.tvlogic = tvlogic;
        }

        // GET: /televisions
        [HttpGet]
        public IEnumerable<Television> GetAll()
        {
            return tvlogic.ReadAll();
        }

        // POST /televisions
        [HttpPost]
        public void Post([FromBody] Television value)
        {
            try
            {
                tvlogic.Create(value);
            }
            catch (ArgumentNullException)
            {
                //no foreign key given,throw status code
            }
        }

        // PUT /televisions/id
        [HttpPut]
        public void Put([FromBody] Television value)
        {
            try
            {
                tvlogic.Update(value);
            }
            catch (Exception )
            {
                //id or model is not given, cannot u
            }
           
        }

        // DELETE /televisions/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                tvlogic.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                //id shouldnt be negative,status code
            }
            
        }
        [HttpGet("{id}")]
        public Television Read(int id)
        {
            try
            {
                return tvlogic.ReadOne(id);
            }
            catch (ArgumentOutOfRangeException)
            {
               //negative Id doesnt exist in database,should throw status code
               return null;
            }
            
        }
    }
}
