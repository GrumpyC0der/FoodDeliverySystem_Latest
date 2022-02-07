using FoodDeliverySystem.Server.Interfaces;
using FoodDeliverySystem.Server.Models;
using FoodDeliverySystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Server.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersContoller : ControllerBase
    {

        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public CustomersContoller(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            try
            {
                return  await Task.FromResult(db.Customers.ToList());
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer Customer = new Customer();
            try
            {
                Customer? customer = db.Customers.Find(id);
                if (customer != null)
                {
                    Customer= customer;
                }
                else
                {
                    Customer = null;                }
            }
            catch
            {
                throw;
            }
            if (Customer != null)
            {
                return Ok(Customer);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Customer Customer)
        {
            try
            {
                db.Customers.Add(Customer);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(Customer Customer)
        {
            try
            {
                db.Entry(Customer).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
            return Ok();
        }
    }
}
