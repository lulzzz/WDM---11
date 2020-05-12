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
        void AddItem(Stock item);
        //TODO
        void RemoveItem(Stock item);

        Task<decimal> GetTotalCost();
    }
}
