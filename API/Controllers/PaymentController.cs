using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // /payment/pay/{user_id}/{order_id}
        // /payment/cancel/{user_id}/{order_id}
        // /payment/status/{order_id}

        private readonly IClusterClient _client;
        public PaymentController(IClusterClient client)
        {
            _client = client;
        }
    }
}
