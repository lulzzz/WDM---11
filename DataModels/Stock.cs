using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Stock
    {
        public string Description { get; set; }
        public int Amount { get; set; } = 0;
        public decimal Credit { get; private set; } = 0;

        //NonSerializable
        public bool Exists => Description != null;
    }
}
