using FoodDeliverySystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Server.Interfaces
{
    public interface ICustomer
    {
        public List<Customer> GetAll();
        public void Add(Customer customer);
        public void Update(Customer customer);
        public Customer Get(int id);
        public void Delete(int id);
    }
}
