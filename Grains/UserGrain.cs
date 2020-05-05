using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class UserGrain : Orleans.Grain, IUserGrain
    {
        User user = new User();

        public Task<bool> ChangeCredit(decimal amount)
        {
            if(user.Credit + amount > 0)
            {

                user.Credit += amount;
                return Task.Factory.StartNew(() => true);
            }
            return Task.Factory.StartNew(() => false);
        }

        public Task<decimal> GetCredit()
        {
            return Task.Factory.StartNew(() => user.Credit);
        }

        public Task<User> GetUser()
        {
            return Task.Factory.StartNew(() => user);
        }
    }
}
