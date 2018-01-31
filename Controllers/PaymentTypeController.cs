using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangazonApi.Data;
using BangazonApi.Models;

namespace BangazonApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentTypeController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public PaymentTypeController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var paymentTypes = _context.PaymentType.ToList();
            if (paymentTypes == null)
            {
                return NotFound();
            }
            return Ok(paymentTypes);
        }

        // GET api/PaymentType/5
        [HttpGet("{id}", Name = "GetSinglePaymentType")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PaymentType paymentType = _context.PaymentType.Single(g => g.Id == id);

                if (paymentType == null)
                {
                    return NotFound();
                }

                return Ok(paymentType);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentTypeExists(paymentType.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSinglePaymentType", new { id = paymentType.Id }, paymentType);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.Id)
            {
                return BadRequest();
            }
            _context.PaymentType.Update(paymentType);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PaymentType paymentType = _context.PaymentType.Single(g => g.Id == id);

            if (paymentType == null)
            {
                return NotFound();
            }
            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        private bool PaymentTypeExists(int Id)
        {
            return _context.PaymentType.Any(g => g.Id == Id);
        }

    }
}