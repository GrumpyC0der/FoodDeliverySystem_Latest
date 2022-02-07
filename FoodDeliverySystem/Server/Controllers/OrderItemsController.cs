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
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemsItemsController : ControllerBase
    {

        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public OrderItemsItemsController(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderItems>> Get(int id)
        {

            try
            {
                return await Task.FromResult(db.OrderItems.Where(x=>x.OrderId==id).Include(x=>x.Food).ToList());
            }
            catch
            {
                throw;
            }
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    OrderItems OrderItems = new OrderItems();
        //    try
        //    {
        //        OrderItems? orderItems = db.OrderItems.Find(id);
        //        if (orderItems != null)
        //        {
        //            OrderItems = orderItems;
        //        }
        //        else
        //        {
        //            OrderItems = null;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    if (OrderItems != null)
        //    {
        //        return Ok(OrderItems);
        //    }
        //    return NotFound();
        //}
        [HttpPost]
        public void Post(OrderItems OrderItems)
        {
            Order order = new Order();
            Food food = new Food();

            try
            {
                order = db.Orders.Find(OrderItems.OrderId);
                food = db.Foods.Find(OrderItems.FoodID);

                long qty = Convert.ToInt64(OrderItems.OrderQuantity);
                long price = Convert.ToInt64(food.FoodPrice);
                long totalprice = qty * price;
                order.OrderFee = (Convert.ToInt64(order.OrderFee) + totalprice).ToString();
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();

                db.OrderItems.Add(OrderItems);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(OrderItems OrderItems)
        {
            Order order = new Order();
            Food food = new Food();

            try
            {
                 order = db.Orders.Find(OrderItems.OrderId);
                food = db.Foods.Find(OrderItems.FoodID);

                long qty = Convert.ToInt64(OrderItems.OrderQuantity);
                long price = Convert.ToInt64(food.FoodPrice);
                long totalprice = qty * price;
                order.OrderFee = (Convert.ToInt64(order.OrderFee) + totalprice).ToString();
                db.Entry(order).State = EntityState.Modified;

                db.Entry(OrderItems).State = EntityState.Modified;
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
                OrderItems? orderItems = db.OrderItems.Find(id);
                if (orderItems != null)
                {
                    db.OrderItems.Remove(orderItems);
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
