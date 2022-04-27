using BGITXA_HFT_2021221.Endpoint.Services;
using BGITXA_HFT_2021221.Logic;
using BGITXA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BGITXA_HFT_2021221.Endpoint.Controllers
{
    [Route("Television")]//          /default route
    [ApiController]
    public class TelevisionController : ControllerBase
    {
        ITelevisionLogic tvlogic;
        IHubContext<SignalRHub> hub;

        public TelevisionController(ITelevisionLogic tvlogic, IHubContext<SignalRHub> hub)
        {
            this.tvlogic = tvlogic;
            this.hub = hub;
        }

        // GET: /television
        [HttpGet]
        public IEnumerable<Television> GetAll()
        {
            return tvlogic.ReadAll();
        }

        // POST /television
        [HttpPost]
        public void Post([FromBody] Television value)
        {
            try
            {
                tvlogic.Create(value);
                hub.Clients.All.SendAsync("TelevisionCreated", value);
            }
            catch (ArgumentNullException)
            {
                //no foreign key given,throw status code
            }
        }

        // PUT /television/id
        [HttpPut]
        public void Put([FromBody] Television value)
        {
            try
            {
                tvlogic.Update(value);
                hub.Clients.All.SendAsync("TelevisionUpdated", value);
            }
            catch (ArgumentNullException)
            {
                //id or model is not given
            }
           
        }

        // DELETE /television/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var value = tvlogic.ReadOne(id);
                tvlogic.Delete(id);
                hub.Clients.All.SendAsync("TelevisionDeleted", value);
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
