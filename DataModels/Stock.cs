using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Stock
    {
        public int? Quantity { get; set; } = null;
        public decimal Price { get; set; }

        [JsonIgnore]
        public bool Exists => Quantity != null;
    }
}
