using DataModels;
using Orleans;
using System;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class OrderGrain : Orleans.Grain, IOrderGrain
    {
        Order order = new Order();

        // STATE?

        public Task<Guid> CreateOrder(Guid userId) //userId or IUserGrain?
        {
            order.Create(userId);
            return Task.FromResult(this.GetPrimaryKey());
        }

        public Task<bool> RemoveOrder()
        {
            bool result = false;

            if (order.Exists)
            {
                order = new Order(); // resets timestamp
                result = true;
            }

            return Task.FromResult(result);
        }
        public Task<Order> GetOrder()
        {
            if (order.Exists)
            {
                return Task.FromResult(order);
            }
            else
            {
                return Task.FromResult<Order>(null); //Throw exception?;
            }
        }

        public Task AddItem()
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem()
        {
            throw new NotImplementedException();
        }
    }
}
