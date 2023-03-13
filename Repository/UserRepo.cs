using BusSystem.API.Model;
using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class UserRepo : IUserRepo
    {
        private BusDbContext _busDb;

        public UserRepo(BusDbContext busDb)
        {
            _busDb = busDb;
        }

        #region GetAllUser
        public List<User> GetAllUser()
        {
            List<User> users = null;
            try
            {
                users = _busDb.users.ToList();
            }
            catch (Exception ex)
            {

            }

            return users;
        }
        #endregion

        #region GetUser


        public User GetUser(int UserId)
        {
            User user = null;
            try
            {
                user = _busDb.users.Find(UserId);

            }
            catch (Exception ex)
            {

            }
            return user;
        }
        #endregion

        #region GetUserbyEmail
        public User GetUserbyEmail(string Email)
        {
            User user = null;
            try
            {
                user = _busDb.users.FirstOrDefault(q => q.Email == Email);

            }
            catch (Exception ex)
            {

            }
            return user;
        }
        #endregion

        #region SaveUser
        public double SaveUser(User user)
        {
            double message = 0.00;
            try
            {
                User userd = GetUserbyEmail(user.Email);
                if (userd != null)
                {
                    message = 1.00;
                }
                else
                {
                    _busDb.users.Add(user);

                    _busDb.SaveChanges();

                    message = 0.00;

                }


            }
            catch (Exception ex)
            {

            }

            return message;
        }
        #endregion

        #region UpdateUser
        public string UpdateUser(User user)
        {
            try
            {
                _busDb.Entry(user).State = EntityState.Modified;
                _busDb.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return "Updated";
        }
        #endregion
    }
}