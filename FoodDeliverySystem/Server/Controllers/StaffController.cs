using FoodDeliverySystem.Server.Models;
using FoodDeliverySystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Server.Controllers
{

    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
        public StaffController(FoodDeliveryDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpGet]
        public async Task<List<Staff>> Get()
        {
            try
            {
                return await Task.FromResult(db.Staffs.ToList());
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Staff Staff = new Staff();
            try
            {
                Staff? staff = db.Staffs.Find(id);
                if (staff != null)
                {
                    Staff = staff;
                }
                else
                {
                    Staff = null;
                }
            }
            catch
            {
                throw;
            }
            if (Staff != null)
            {
                return Ok(Staff);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Staff Staff)
        {
            try
            {
                db.Staffs.Add(Staff);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        public void Put(Staff Staff)
        {
            try
            {
                db.Entry(Staff).State = EntityState.Modified;
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
                Staff? staff = db.Staffs.Find(id);
                if (staff != null)
                {
                    db.Staffs.Remove(staff);
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
