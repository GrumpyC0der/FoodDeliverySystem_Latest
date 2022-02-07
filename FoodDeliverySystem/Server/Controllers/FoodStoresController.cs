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
    [Route("api/foodstores")]
    [ApiController]
    public class FoodStoresController : ControllerBase
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public FoodStoresController(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet]
        public async Task<List<FoodStores>> Get()
        {
            try
            {
                return await Task.FromResult(db.FoodStores.ToList());
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FoodStores FoodStores = new FoodStores();
            try
            {
                FoodStores? customer = db.FoodStores.Find(id);
                if (customer != null)
                {
                    FoodStores = customer;
                }
                else
                {
                    FoodStores = null;
                }
            }
            catch
            {
                throw;
            }
            if (FoodStores != null)
            {
                return Ok(FoodStores);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(FoodStores FoodStores)
        {
            try
            {
                db.FoodStores.Add(FoodStores);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(FoodStores FoodStores)
        {
            try
            {
                db.Entry(FoodStores).State = EntityState.Modified;
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
                FoodStores? customer = db.FoodStores.Find(id);
                if (customer != null)
                {
                    db.FoodStores.Remove(customer);
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
