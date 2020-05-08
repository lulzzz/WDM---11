using DataModels;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class UserGrain : Orleans.Grain, IUserGrain
    {
        //This object should be changed to persistentstate/transactionalstate to allow persistence or transactions. 
        User user = new User();
        State State = new State();//Used to check if the grain was already created.

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

        public Task<Guid> CreateUser()
        {
            State.Created = true;

            return Task.FromResult(this.GetPrimaryKey());

        }

        public Task<decimal> GetCredit()
        {
            return Task.Factory.StartNew(() => user.Credit);
        }

        //Use this to check if user was created before, therefore if it exists in the other methods.
        public Task<User> GetUser()
        {
            if (State.Created)
            {
                return Task.FromResult(user);
            }
            else
            {
                return Task.FromResult<User>(null); //Throw exception?;
            }
        }

        //Should receive the order
        public Task<Guid> NewOrder()
        {
            //Add order to user
            var guid = Guid.NewGuid();
            return Task.FromResult(guid);
        }
    }
}
