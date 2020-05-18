using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    //To be used in order. (Confirm)
    class OrderItem
    {
        public Stock Item { get; set; } //FK ?
        public int Quantity { get; set; }
    }
}
