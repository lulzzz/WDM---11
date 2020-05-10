using DataModels;
using Orleans;
using System;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class UserGrain : Orleans.Grain, IUserGrain
    {
        User user = new User();

        public Task<Guid> CreateUser()
        {
            user.Create();
            return Task.FromResult(this.GetPrimaryKey());
        }

        public Task<bool> RemoveUser()
        {
            bool result = false;

            if (user.Exists)
            {
                user = new User(); // resets timestamp
                result = true;
            }

            return Task.FromResult(result);
        }

        //Use this to check if user was created before, therefore if it exists in the other methods.
        public Task<User> GetUser()
        {
            if (user.Exists)
            {
                return Task.FromResult(user);
            }
            else
            {
                return Task.FromResult<User>(null); //Throw exception?;
            }
        }

        public Task<decimal> GetCredit()
        {
            return Task.Factory.StartNew(() => user.Credit); // ?
        }

        public Task<bool> ChangeCredit(decimal amount)
        {
            bool result = false;

            if(user.Credit + amount > 0)
            {
                user.Credit += amount;
                result = true;
            }

            return Task.FromResult(result);
        }

        // TODO: Necessary?
        //Should receive the order
        public Task<Guid> NewOrder()
        {
            //Add order to user
            var guid = Guid.NewGuid();
            return Task.FromResult(guid);
        }
    }
}
