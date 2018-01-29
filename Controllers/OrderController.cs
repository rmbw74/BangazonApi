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
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public OrderController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _context.Order
            .Include("ProductOrder.Product")
                // .ThenInclude(productorder => productorder.Product)
            .ToList();

            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/Order/5
        [HttpGet("{id}", Name = "GetSingleOrder")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Order Order = _context.Order.Single(g => g.Id == id);

                if (Order == null)
                {
                    return NotFound();
                }

                return Ok(Order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Order.Add(Order);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(Order.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = Order.Id }, Order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Order.Id)
            {
                return BadRequest();
            }
            _context.Order.Update(Order);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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


        //order exists check method
        private bool OrderExists(int Id)
        {
            return _context.Order.Any(g => g.Id == Id);
        }

    }
}