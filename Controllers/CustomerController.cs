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
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public CustomerController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        //this action will get customers
        [HttpGet]
        public IActionResult Get(bool? active)
        {
            //if no bool was passed, return all customers
            if(active == null){
            var customers = _context.Customer.ToList();
                //if customers = null return notfound
                if (customers == null)
                {
                return NotFound();
                }
                //else return all customers
                return Ok(customers);

            } else
                {
                if(active == false) //if the bool false is passed
                {
                var orders = _context.Orders;
                var customers = _context.Customer;
                //find all customers who have not acutally placed an order yet = order.Time is null
                var query = (from c in customers
                            join o in orders on c.Id equals o.CustomerId into custord
                            from o in custord.DefaultIfEmpty()
                            where o.Time == null
                            select c);
                return Ok(query);


                }
                else //if the bool true is passed
                    {
                    var orders = _context.Orders;
                    var customers = _context.Customer;
                    //find all customers who have placed an order order.Time is not null
                    var query = (from c in customers
                            join ord in orders on c.Id equals ord.CustomerId where ord.Time != null select c);
                return Ok(query);

                }


            }
        }

        // GET api/Customer/5
        [HttpGet("{id}", Name = "GetSingleCustomer")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer Customer = _context.Customer.Single(g => g.Id == id);

                if (Customer == null)
                {
                    return NotFound();
                }

                return Ok(Customer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(Customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(Customer.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleCustomer", new { id = Customer.Id }, Customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Customer.Id)
            {
                return BadRequest();
            }
            _context.Customer.Update(Customer);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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


        //customer exists check method
        private bool CustomerExists(int Id)
        {
            return _context.Customer.Any(g => g.Id == Id);
        }

    }
}