using DataModels;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface IUserGrain : IGrainWithGuidKey
    {
        Task<Guid> CreateUser();
        Task<User> GetUser();

        Task<decimal> GetCredit();

        Task<bool> ChangeCredit(decimal amount);

        Task<Guid> NewOrder();
    }
}
