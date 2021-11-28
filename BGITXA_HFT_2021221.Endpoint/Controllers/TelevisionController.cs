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

        // GET api/<TelevisionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TelevisionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TelevisionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TelevisionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
