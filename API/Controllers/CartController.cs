using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using OrleansBasics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IClusterClient _client;
        public CartController(IClusterClient client)
        {
            _client = client;
        }
        // GET: api/Cart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "Get")]
        public Task<Cart> Get(Guid guid)
        {   //Can it receive directly a GUID?
            var cart = _client.GetGrain<ICartGrain>(guid); //Get specific cart. How to handle auth ?
            return cart.GetCart();
            
        }

        // POST: api/Cart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
