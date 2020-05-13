using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class StockGrain : Orleans.Grain, IStockGrain
    {
        Stock stock = new Stock();

        public Task ChangeAmount(int amount)
        {
            if (!stock.Exists)
            {
                throw new Exception("Item does not exist");
            }
            if(stock.Quantity + amount > 0)
            {
                stock.Quantity += amount;
            }
            else
            {
                throw new Exception("Not enough stock.");
            }
            return Task.FromResult(0);
        }

        public Task<Stock> GetStock()
        {
            if (!stock.Exists)
            {
                throw new Exception("Item does not exist");
            }
            return Task.FromResult(stock);
        }

        public Task<int> GetAmount()
        {
            if(!stock.Exists)
            {
                throw new Exception("Item does not exist");
            }
            return Task.FromResult(stock.Quantity.Value);
        }

        public void Create(decimal price)
        {
            stock.Price = price;
        }
    }
}
