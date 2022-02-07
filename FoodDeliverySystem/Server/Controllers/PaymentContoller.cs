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
    [Route("api/payment")]
    [ApiController]
    public class PaymentContoller : ControllerBase
    {
            readonly FoodDeliveryDbContext db = new FoodDeliveryDbContext();
            public PaymentContoller(FoodDeliveryDbContext dbContext)
            {
                db = dbContext;
            }
            [HttpGet]
            public async Task<IEnumerable<Payment>> Get()
            {

                try
                {
                    return await Task.FromResult(db.Payments.Include(x => x.Order).ToList());
                }
                catch
                {
                    throw;
                }
            }
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                Payment Payment = new Payment();
                try
                {
                    Payment? payment = db.Payments.Find(id);
                    if (payment != null)
                    {
                        Payment = payment;
                    }
                    else
                    {
                        Payment = null;
                    }
                }
                catch
                {
                    throw;
                }
                if (Payment != null)
                {
                    return Ok(Payment);
                }
                return NotFound();
            }
            [HttpPost]
            public void Post(Payment Payment)
            {
                try
                {
                    db.Payments.Add(Payment);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            [HttpPut]
            public void Put(Payment Payment)
            {
                try
                {
                    db.Entry(Payment).State = EntityState.Modified;
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
                    Payment? payment = db.Payments.Find(id);
                    if (payment != null)
                    {
                        db.Payments.Remove(payment);
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
