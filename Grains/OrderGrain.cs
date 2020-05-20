﻿using DataModels;
using Orleans;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class OrderGrain : Grain, IOrderGrain
    {
        private readonly IPersistentState<Order> _order;

        public OrderGrain([PersistentState("order", "wdmgroup11")] IPersistentState<Order> order)
        {
            _order = order;
        }

        public Task<Guid> CreateOrder(Guid userId) //userId or IUserGrain?
        {
            _order.State.Create(userId);
            return Task.FromResult(this.GetPrimaryKey());
        }

        public Task<bool> RemoveOrder()
        {
            bool result = false;

            if (_order.State.Exists)
            {
                _order.State = new Order(); // resets timestamp
                result = true;
            }

            return Task.FromResult(result);
        }

        public Task<Order> GetOrder()
        {
            if (_order.State.Exists)
            {
                return Task.FromResult(_order.State);
            }

            return Task.FromResult<Order>(null); //Throw exception?;
        }

        public void AddItem(Stock item)
        {
            _order.State.Items.Add(item);
        }

        public void RemoveItem(Stock item)
        {
            _order.State.Items.Remove(item);
        }

        public Task<decimal> GetTotalCost()
        {
            if (!_order.State.Exists)
            {
                throw new OrderDoesNotExistsException();
            }
            _order.WriteStateAsync();

            return Task.FromResult(_order.State.Total);
        }

        public Task<bool> GetStatus()
        {
            return Task.FromResult(_order.State.Exists && _order.State.Completed);
        }

        public Task<bool> Checkout()
        {
            if (!_order.State.CanCheckout) return Task.FromResult(false);
            
            // foreach (Stock item in order.Items)
            // {
            //     //ToDo: subtract stock.
            // }
            
            _order.State.Checkout();

            return Task.FromResult(true);
        }

        //Complete === Checkout ?
        public Task<bool> Complete()
        {
            _order.State.Complete();
            
            return Task.FromResult(true);
        }
        
        public Task<bool> CancelCheckout()
        {
            if (!_order.State.CheckedOut) return Task.FromResult(false);
            
            // foreach (Stock item in order.Items)
            // {
            //     //ToDo: revert stock transaction.
            // }
            
            _order.State.CancelCheckout();

            return Task.FromResult(true);
        }

        public Task<Guid> GetUser()
        {
            if (_order.State.Exists)
            {
                return Task.FromResult(this.GetPrimaryKey());
            }
            throw new OrderDoesNotExistsException();
        }
    }
}