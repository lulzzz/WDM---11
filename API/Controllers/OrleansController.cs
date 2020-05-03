using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using Orleans.Configuration;
using OrleansBasics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrleansController : ControllerBase
    {
        private readonly IClusterClient _client;
        public OrleansController(IClusterClient client)
        {
            _client = client;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            var friend = _client.GetGrain<IHello>(0);
            var response = await friend.SayHello("Good morning, HelloGrain!");
            return response;
        }

        

     
    }
}
