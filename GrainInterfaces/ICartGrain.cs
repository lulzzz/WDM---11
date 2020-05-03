using DataModels;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface ICartGrain : IGrainWithGuidKey

    {   //From which user?
        Task<Cart> GetCart();

        //From which user?
        Task<List<Product>> GetProducts();

        //To which user?
        Task AddProduct(Product product);
    }
}
