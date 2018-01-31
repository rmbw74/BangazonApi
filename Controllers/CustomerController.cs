//Authors : Ray Medrano , Chris Miller
//Purpose : This controller allows bangazonians access to the customer resource
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
        //this action will get customers - the active bool is a parameter - when passed true or false it will return a list of customers that are considered inactive(false) or active(true)
        //an inactive customer is one who has never completed an order on the order table.
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
                //find all customers who have not placed an order on the order table, or never placed an order.
                //placed order = Order.Time = null
                var query =
                        from c in customers
                        where !(from o in orders where o.Time != null select o.CustomerId).Any(id => id == c.Id)
                        select c;
                return Ok(query);


                }
                else //if the bool true is passed
                    {
                    var orders = _context.Orders;
                    var customers = _context.Customer;
                    //find all customers who have placed an order order.Time is not null
                    var query =
                        from c in customers
                        where (from o in orders where o.Time != null select o.CustomerId).Any(id => id == c.Id)
                        select c;
                return Ok(query);

                }


            }
        }

        // GET api/Customer/{id}
        // this method will return the details of a single customer when the customer Id is appeneded to the URL
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
                return NotFound(ex);
            }
        }

        // POST api/customer
        // This method with post a new customer to the database
        // with the following format "firstName": <string>, "lastName": <string>,"lastActive": <string>
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

        // PUT api/customer/{id}
        //This method will update an existing customer in the database where the id on the url = customer id
        //with the following format, the id must match the id in the url
        //"id": int,  "firstName": <string>, "lastName": <string>,"lastActive": <string>
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