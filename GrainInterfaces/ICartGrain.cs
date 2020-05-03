using DataModels;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface ICartGrain : IGrainWithGuidKey
    { 
        Task<Cart> GetCart();

        Task<List<Product>> GetProducts();

        Task AddProduct(Product product);
    }
}
