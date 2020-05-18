using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataModels
{
    public class User
    {
        
        public decimal Credit { get; set; } = 0;

        public DateTime? CreatedAt { get; private set; } = null;
        // public Dictionary<Guid, Order> Orders { get; set; } NECESSARY?

        // TODO: Non Serializable
        [JsonIgnore]
        public bool Exists => CreatedAt != null;

        public void Create()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
