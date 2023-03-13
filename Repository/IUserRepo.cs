using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IUserRepo
    {
        public double SaveUser(User user);
        public string UpdateUser(User user);
        User GetUser(int UserId);
        User GetUserbyEmail(string Name);
        List<User> GetAllUser();
    }
}