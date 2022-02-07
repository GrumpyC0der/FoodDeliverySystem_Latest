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
    [Route("api/order")]
    [ApiController]
    public class OrderContoller : ControllerBase
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public OrderContoller(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {

            try
            {
                return await Task.FromResult(db.Orders.Include(x=>x.Customer).ToList());
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Order Order = new Order();
            try
            {
                Order? order = db.Orders.Where(x=>x.OrderId==id).Include(x => x.Customer).Include(x=>x.Staff).First();
                if (order != null)
                {
                    Order = order;
                }
                else
                {
                    Order = null;
                }
            }
            catch
            {
                throw;
            }
            if (Order != null)
            {
                return Ok(Order);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Order Order)
        {
            try
            {
                db.Orders.Add(Order);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(Order Order)
        {
            try
            {
                db.Entry(Order).State = EntityState.Modified;
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
                Order? order = db.Orders.Find(id);
                if (order != null)
                {
                    db.Orders.Remove(order);
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
