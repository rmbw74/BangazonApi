//Author: Chase Steely and Max Wolf
//Purpose: To allow Bangazonians to access the Orders table in the API, allowing them to GET, PUT, POST, and DELETE
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BangazonApi.Data;
using BangazonApi.Models;

namespace BangazonApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public OrdersController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        //Gets all Orders from the API with the Products Join table attached.
        //GET api/Orders/
        [HttpGet]
        public IActionResult Get()
        {
            var order = _context.Orders
            .Select(o => new
            {
                Id = o.Id,
                Time = o.Time,
                CustomerId = o.CustomerId,
                PaymentId = o.PaymentId,
                Products = o.Products
                        .Select(p => p.Product)
            })
            .ToList();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //Gets a single order in the API by id with Product data attached
        // GET api/Orders/id
        [HttpGet("{id}", Name = "GetSingleOrder")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = _context.Orders.Include("Products.Product").Single(g => g.Id == id);

                if (order == null)
                    return NotFound();
                {
                }

                return Ok(order);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // Allows you to post/add a order to the api
        // POST api/Orders
        [HttpPost]
        public IActionResult Post([FromBody]Orders order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleOrder", new { id = order.Id }, order);
        }

        //Allows you to edit data on the Orders table for a single computer by id
        // PUT api/Orders/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Orders order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }
            _context.Orders.Update(order);
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

         //Allows you to delete a row in the Orders table for a single order by id
        // DELETE api/Orders/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Orders order = _context.Orders.Single(g => g.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }

        private bool OrderExists(int OrderId)
        {
            return _context.Orders.Any(g => g.Id == OrderId);
        }

    }
}