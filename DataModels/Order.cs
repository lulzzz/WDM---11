using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Order
    {
        public Guid userId { get; set; } //FK of user

        public List<Stock> Items { get; } = new List<Stock>();

        public DateTime? CreatedAt { get; set; } = null;
        public DateTime? CompletedAt { get; set; } = null;

        //Non serializable
        [JsonIgnore]
        public bool Exists => CreatedAt != null;
        //Non serializable
        public bool Completed => CompletedAt != null;

        public decimal Total => Items.Sum(i => i.Credit);

        public void Create(Guid userId)
        {
            this.userId = userId;
            CreatedAt = DateTime.Now;
        }

        public void Complete()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
