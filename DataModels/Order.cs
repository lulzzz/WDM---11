using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DateTime? CheckedOutAt { get; set; } = null;
        public DateTime? CompletedAt { get; set; } = null;

        //Non serializable
        [JsonIgnore]
        public bool Exists => CreatedAt != null;
        //Non serializable
        [JsonIgnore]
        public bool CheckedOut => CheckedOutAt != null;
        //Non serializable
        [JsonProperty(PropertyName = "paid")]
        public bool Completed => CompletedAt != null;
        [JsonIgnore]
        public bool CanCheckout => Exists && !CheckedOut && !Completed;

        [JsonProperty(PropertyName = "total_cost")]
        public decimal Total => Items.Sum(i => i.Price);

        public void Create(Guid userId)
        {
            this.userId = userId;
            CreatedAt = DateTime.Now;
        }

        public void Checkout()
        {
            CheckedOutAt = DateTime.Now;
        }

        public void Complete()
        {
            CompletedAt = DateTime.Now;
        }
        
        public void CancelCheckout()
        {
            CheckedOutAt = null;
        }
    }
}
