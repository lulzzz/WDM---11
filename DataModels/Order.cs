using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class Order
    {
        public List<Product> Items{get;set;}
        public User User { get; set; }
        //Payment Status
    }
}
