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
            tvlogic.Create(value);
        }

        // PUT /televisions/id
        [HttpPut("{id}")]
        public void Put([FromBody] Television value)
        {
            tvlogic.Update(value);
        }

        // DELETE /televisions/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tvlogic.Delete(id);
        }
        [HttpGet("{id}")]
        public Television Read(int id)
        {
            return tvlogic.ReadOne(id);
        }
    }
}
