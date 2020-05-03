using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class CartGrain : Orleans.Grain, ICartGrain
    {
        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCart()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
