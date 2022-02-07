using FoodDeliverySystem.Server.Interfaces;
using FoodDeliverySystem.Server.Models;
using FoodDeliverySystem.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliverySystem.Server.Services
{
    public class CustomerServices : ICustomer
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public CustomerServices(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        public void Add(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Customer? customer = db.Customers.Find(id);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
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

        public Customer Get(int id)
        {
            try
            {
                Customer? customer = db.Customers.Find(id);
                if (customer != null)
                {
                    return customer;
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

        public List<Customer> GetAll()
        {
            try
            {
                return db.Customers.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
