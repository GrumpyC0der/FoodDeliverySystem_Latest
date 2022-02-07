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
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public FoodController(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Food>> Get()
        {

            try
            {
                return await Task.FromResult(db.Foods.Include(x=>x.FoodStores).ToList());
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Food Food = new Food();
            try
            {
                Food? food = db.Foods.Find(id);
                if (food != null)
                {
                    Food = food;
                }
                else
                {
                    Food = null;
                }
            }
            catch
            {
                throw;
            }
            if (Food != null)
            {
                return Ok(Food);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Food Food)
        {
            try
            {
                db.Foods.Add(Food);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(Food Food)
        {
            try
            {
                db.Entry(Food).State = EntityState.Modified;
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
                Food? food = db.Foods.Find(id);
                if (food != null)
                {
                    db.Foods.Remove(food);
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
