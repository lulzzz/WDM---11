using DataModels;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface IOrderGrain : IGrainWithGuidKey
    {
        Task<Guid> CreateOrder(Guid userId);

        Task<bool> RemoveOrder();

        Task<Order> GetOrder();

        //TODO
        Task AddItem();
        //TODO
        Task RemoveItem();

    }
}
