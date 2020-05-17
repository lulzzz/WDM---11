using DataModels;
using Orleans;
using System;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class OrderGrain : Orleans.Grain, IOrderGrain
    {
        Order order = new Order();
        //UserGrain?

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

            return Task.FromResult<Order>(null); //Throw exception?;
        }

        public void AddItem(Stock item)
        {
            order.Items.Add(item);
        }

        public void RemoveItem(Stock item)
        {
            order.Items.Remove(item);
        }

        public Task<decimal> GetTotalCost()
        {
            if (!order.Exists)
            {
                return null;
            }

            return Task.FromResult(order.Total);
        }

        public Task<bool> GetStatus()
        {
            return Task.FromResult(order.Exists && order.Completed);
        }

        public Task<bool> Checkout()
        {
            if (!order.CanCheckout) return Task.FromResult(false);
            
            // foreach (Stock item in order.Items)
            // {
            //     //ToDo: subtract stock.
            // }
            
            order.Checkout();

            return Task.FromResult(true);
        }

        public Task<bool> Complete()
        {
            order.Complete();
            
            return Task.FromResult(true);
        }
        
        public Task<bool> CancelCheckout()
        {
            if (!order.CheckedOut) return Task.FromResult(false);
            
            // foreach (Stock item in order.Items)
            // {
            //     //ToDo: revert stock transaction.
            // }
            
            order.CancelCheckout();

            return Task.FromResult(true);
        }
    }
}