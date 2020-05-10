using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Order
    {
        public Dictionary<Guid, Stock> Items { get; set; }
        public Guid userId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }

        public bool Exists => CreatedAt != null;

        public void Create(Guid userId)
        {
            this.userId = userId;
            CreatedAt = DateTime.Now;
        }
    }
}
