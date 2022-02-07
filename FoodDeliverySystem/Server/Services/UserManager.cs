using FoodDeliverySystem.Server.Interfaces;
using FoodDeliverySystem.Server.Models;
using FoodDeliverySystem.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Server.Controllers
{
    public class UserManager : IUser
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public UserManager(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        //To Get all user details
        public List<User> GetUserDetails()
        {
            try
            {
                return db.Users.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateUserDetails(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public User GetUserData(int id)
        {
            try
            {
                User? user = db.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                User? user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

      
    }
}